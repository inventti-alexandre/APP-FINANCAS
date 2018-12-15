using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Application.IO.CrossCutting.AspNetFilters
{
    public class GlobalActionLogger : IActionFilter
    {
        private readonly ILogger<GlobalActionLogger> _logger;
        private readonly IHostingEnvironment _hostingEnviroment;
        private readonly IConfigurationRoot _root;

        public GlobalActionLogger(ILogger<GlobalActionLogger> logger, IHostingEnvironment hostingEnviroment)
        {
            _logger = logger;
            _hostingEnviroment = hostingEnviroment;
            _root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var arg = context.ActionArguments["version"];
            if (arg == null || arg.ToString() != _root.GetSection("version").Value)
                context.Result = new UnauthorizedResult();
        }
    }
}
