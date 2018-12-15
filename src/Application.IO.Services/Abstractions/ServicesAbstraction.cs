using Application.IO.Core.Context;
using Application.IO.Core.Domain.Source.Notifications;
using Application.IO.Core.Domain.Source.Notifications.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Application.IO.Services.Abstractions
{
    public abstract class ServicesAbstraction
    {
        public IAppNotificationHandler<DomainNotification> Errors => Errors ?? new DomainNotificationHandler();

        public bool EhValido => Errors.Get.Any();

        protected ApplicationDbContext db;

        public ServicesAbstraction()
        {
            var bild = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("DefaultConnection"));

            db = new ApplicationDbContext(bild.Options);
        }
    }
}
