using Application.IO.Core.Domain.Source.Notifications;
using Application.IO.Core.Domain.Source.Notifications.Interfaces;
using Application.IO.Core.Identity.Interfaces;
using Application.IO.Core.Identity.Models;
using Application.IO.Core.Identity.Services;
using Application.IO.CrossCutting.AspNetFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.IO.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

            // Domain - Core
            services.AddScoped<IAppNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
        }
    }
}
