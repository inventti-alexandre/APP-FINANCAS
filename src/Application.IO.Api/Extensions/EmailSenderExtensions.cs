using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Application.IO.Api.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link, string userName)
        {
            return emailSender.SendEmailAsync(email, "Seja Bem Vindo",
                $"Olá {userName}, estamos gratos pelo seu ingresso em nossa plataforma.<br><br>Confirme <a href='{link}'>aqui</a> sua conta para continuar seu cadastro.<br><br><b style=\"font-size:12px;\">*Caso necessário copie e cole em seu browzer o link a seguir: {link}</b><br><br>Desejamos a você bons negócios!");
        }
    }
}
