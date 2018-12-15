using Application.IO.Api.Configurations;
using Application.IO.Api.Middlewares;
using Application.IO.Core.Context;
using Application.IO.CrossCutting.AspNetFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IO.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Contexto do DB
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configurações de Autenticação, Autorização e JWT.
            services.AddMvcSecurity(Configuration);

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // MVC com restrição de XML e adição de filtro de ações.
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalActionLogger)));
            });

            // Versionamento do WebApi
            services.AddApiVersioning("api/v{version}");

            // Configurações do Swagger
            services.AddSwaggerConfig();

            // Registrar todos os DI
            services.AddDIConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region MVC
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            #endregion

            #region Swagger
            if (env.IsProduction())
            {
                // Se não tiver um token válido no browser não funciona.
                // Descomente para ativar a segurança.
                // app.UseSwaggerAuthorized();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Plano ADV v1.0");
            });
            #endregion

            #region Deploy
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseSwaggerAuthorized();
            #endregion
        }
    }
}
