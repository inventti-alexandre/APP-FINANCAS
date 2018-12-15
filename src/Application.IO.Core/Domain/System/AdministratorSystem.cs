using Application.IO.Core.Domain.Source.Models;
using Application.IO.Core.Identity.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Core.Domain.System
{
    // Usuários administradores do sistema
    public class AdministratorSystem : Entity
    {
        [Display(Name = "Cód. Usuário")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        public Guid IdApplicationUser { get; private set; }

        public AdministratorSystem(Guid idApplicationUser)
        {
            IdApplicationUser = idApplicationUser;
        }

        // EF Construtor
        protected AdministratorSystem() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
