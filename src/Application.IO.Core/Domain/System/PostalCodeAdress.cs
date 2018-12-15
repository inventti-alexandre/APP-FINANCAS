using Application.IO.Core.Domain.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Core.Domain.System
{
    //CEP
    public class PostalCodeAdress : Entity
    {
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        [MinLength(8, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(8, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string Code { get; private set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        [MinLength(3, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string Place { get; private set; }

        [Display(Name = "Bairro")]
        [MinLength(3, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string Neighborhood { get; private set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        [MinLength(3, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string City { get; private set; }

        [Display(Name = "Sigla Estado")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        [MinLength(2, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(2, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string State { get; private set; }

        [Display(Name = "Nome Estado")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        [MinLength(3, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string StateName { get; private set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "O campo \"{0}\" é obrigatorio")]
        [MinLength(3, ErrorMessage = "O campo \"{0}\" deve possuir no mínimo {1} caracteres")]
        [MaxLength(40, ErrorMessage = "O campo \"{0}\" deve possuir no máximo {1} caracteres")]
        public string Country { get; private set; }

        [Required]
        public bool InsertByUser { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        public PostalCodeAdress(string code, string place, string neighborhood, string city, string state, string stateName, string country)
        {
            Code = code;
            Place = place;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            StateName = stateName;
            Country = country;
            InsertByUser = true;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected PostalCodeAdress() { }
    }
}
