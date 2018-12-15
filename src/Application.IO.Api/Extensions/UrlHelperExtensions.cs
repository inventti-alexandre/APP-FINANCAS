using Application.IO.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Application.IO.Api.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string token, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.EmailConfirm),
                controller: "Account",
                values: new { userId, token },
                protocol: scheme);
        }

        //public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        //{
        //    return urlHelper.Action(
        //        action: "", //FALTA CRIAR A ACTION
        //        controller: "Account",
        //        values: new { userId, code },
        //        protocol: scheme);
        //}
    }
}
