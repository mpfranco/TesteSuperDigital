
using System.ComponentModel.DataAnnotations;

namespace Conta.Api.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo {0} esta em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo {0} precisa ter entre {2} e {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
