using System.ComponentModel.DataAnnotations;

namespace Application.IO.Core.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "O campo \"{0}\" deve ter entre {2} e {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "O campo \"{0}\" deve ter entre {2} e {1} caracteres")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [StringLength(maximumLength: 256, MinimumLength = 3, ErrorMessage = "O campo \"{0}\" deve ter entre {2} e {1} caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O campo \"{0}\" não é válido")]
        public string Email { get; set; }

        [Display(Name = "Confirmar E-mail")]
        [Compare("Email", ErrorMessage = "O campo \"E-mail\" e \"{0}\" devem ser iguais")]
        public string EmailConf { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [StringLength(maximumLength: 10, MinimumLength = 8, ErrorMessage = "O campo \"{0}\" deve ter entre {2} e {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "O campo \"Senha\" e \"{0}\" devem ser iguais")]
        public string PasswordConf { get; set; }
    }
}
