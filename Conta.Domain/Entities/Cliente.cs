using FluentValidation;
using Conta.Domain.Base;



namespace Conta.Domain.Entities
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public string NmCliente { get; set; }
        public string CPF { get; set; }        
        public override bool EstaConsistente()
        {
            RuleFor(x => x.NmCliente)
               .NotEmpty().WithMessage("O campo NmCliente deve ser preenchido")
               .Length(2, 50).WithMessage("O campo NmCliente precisa ter entre 2 e 50 caracteres");

            RuleFor(x => x.CPF)
               .NotEmpty().WithMessage("O campo CPF deve ser preenchido")
               .Length(11).WithMessage("O campo CPF precisa ter  11 caracteres");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
