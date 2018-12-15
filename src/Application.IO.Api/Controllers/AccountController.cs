using Application.IO.Api.Extensions;
using Application.IO.Core.Domain.Source.Notifications;
using Application.IO.Core.Domain.Source.Notifications.Interfaces;
using Application.IO.Core.Identity.Authorization;
using Application.IO.Core.Identity.Interfaces;
using Application.IO.Core.Identity.Models;
using Application.IO.Core.Identity.Models.AccountViewModels;
using Application.IO.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.IO.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly TokenDescriptor _tokenDescriptor;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            TokenDescriptor tokenDescriptor,
            IUser user,
            IAppNotificationHandler<DomainNotification> notification) : base(user, notification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _tokenDescriptor = tokenDescriptor;
        }

        #region AUX
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private object GenerateTokenUser(LoginViewModel login)
        {
            var user = _userManager.FindByEmailAsync(login.Email).Result;
            var userClaims = _userManager.GetClaimsAsync(user).Result;

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            // Necessário converver para IdentityClaims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(userClaims);

            var handler = new JwtSecurityTokenHandler();
            var signingConf = new SigningCredentialsConfiguration();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenDescriptor.Issuer,
                Audience = _tokenDescriptor.Audience,
                SigningCredentials = signingConf.SigningCredentials,
                Subject = identityClaims,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid)
            });

            var response = new
            {
                access_token = handler.WriteToken(securityToken),
                expires_in = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid),
                user = new
                {
                    id = user.Id,
                    nome = $"{user.Name} {user.LastName}",
                    email = user.Email,
                    claims = userClaims.Select(c => new { c.Type, c.Value })
                }
            };

            return response;
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("account/usereg")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model, int version)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { sucess = false, errors = ModelState.Values.SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage).ToList() });

            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(new { sucess = false, errors = result.Errors.Select(s => s.Description) });

            await _emailSender.SendEmailConfirmationAsync(model.Email,
                
                Url.EmailConfirmationLink(
                    user.Id.ToString(),
                    _userManager.GenerateEmailConfirmationTokenAsync(user).Result,
                    Request.Scheme),

                $"{user.Name} {user.LastName}");

            return Ok(new { sucess = true });
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model, int version)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { sucess = false, errors = ModelState.Values.SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage).ToList() });

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.IsLockedOut)
                return BadRequest(new { sucess = false, errors = "Muitas tentativas de login foram executadas e o usuário está temporariamente bloqueado" });

            if (result.IsNotAllowed)
                return BadRequest(new { sucess = false, errors = "Ainda não é permitido o login, verifique se a confirmação de e-mail foi feita" });

            //Código de controle de data de confirmação de email
            new UserUpdateServices().UpdateUserEmailConfirm(model.Email);

            return Ok(new
            {
                success = true,
                data = GenerateTokenUser(model)
            });
        }

        [HttpPost]
        [Route("account/logout")]
        public async Task<IActionResult> Logout(int version)
        {
            await _signInManager.SignOutAsync();

            return Ok(new { sucess = true });
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("account/econfirm")]
        public IActionResult EmailConfirm(string userId, string token, int version)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return BadRequest(new { sucess = false, errors = "\"Identificador\", ou \"Código de Confirmação\" do Usuário incorretos" });

            var user = _userManager.FindByIdAsync(userId).Result;
            if (user == null)
                return BadRequest(new { sucess = false, errors = "Usuário não foi encontrado" });

            var result = _userManager.ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                new UserUpdateServices().UpdateUserEmailConfirm(user.Email);

                return Ok(new { sucess = true });
            }
            else
                return BadRequest(new { sucess = false, errors = result.Errors.Select(s => s.Description) });
        }
        #endregion
    }
}
