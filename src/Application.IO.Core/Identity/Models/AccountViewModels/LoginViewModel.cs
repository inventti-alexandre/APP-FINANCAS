using System.ComponentModel.DataAnnotations;

namespace Application.IO.Core.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
