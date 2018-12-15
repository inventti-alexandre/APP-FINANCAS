using Application.IO.Core.Context.Extensions;
using Application.IO.Core.Context.Mappings.Customers;
using Application.IO.Core.Context.Mappings.System;
using Application.IO.Core.Domain.Customers;
using Application.IO.Core.Domain.System;
using Application.IO.Core.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Application.IO.Core.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public virtual DbSet<AdministratorSystem> AdministratorsSystem { get; set; }
        //public virtual DbSet<PostalCodeAdress> PostalCodesAdress { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Sistema
            modelBuilder.AddConfiguration(new AdministratorSystemMapping());
            //modelBuilder.AddConfiguration(new PostalCodeAdressMapping());

            //Usuários não adm
            modelBuilder.AddConfiguration(new CustomerMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
