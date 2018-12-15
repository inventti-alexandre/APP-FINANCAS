using Application.IO.Core.Domain.Customers;
using Application.IO.Core.Domain.System;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Core.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required, MaxLength(40)]
        public string LastName { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime UserCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UserEmailConfirm { get; set; }

        [Required]
        public bool LogicalDeleted { get; set; }

        public ApplicationUser()
        {
            UserCreated = DateTime.Now;
        }

        // EF Propriedade de Navegação
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<AdministratorSystem> AdmUsersSystem { get; set; }
    }
}
