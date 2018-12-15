using Application.IO.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IO.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
