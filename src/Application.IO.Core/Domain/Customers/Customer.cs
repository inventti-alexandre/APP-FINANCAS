using Application.IO.Core.Domain.Source.Models;
using Application.IO.Core.Identity.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.IO.Core.Domain.Customers
{
    // Clientes
    //[Table("Customers")]
    public class Customer : Entity
    {
        [Display(Name = "Cód. Usuário")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        //[ForeignKey("ApplicationUser")]
        public Guid IdApplicationUser { get; private set; }

        public Customer(Guid idApplicationUser)
        {
            IdApplicationUser = idApplicationUser;
        }

        // EF Construtor
        protected Customer() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
