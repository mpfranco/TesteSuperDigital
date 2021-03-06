﻿

using System.ComponentModel.DataAnnotations;

namespace Conta.Presentation.Api.ViewModels
{
    public class RegistrerUserViewModel
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo {0} esta em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo {0} precisa ter entre {2} e {1}", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
