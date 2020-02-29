using FluentValidation;
using Conta.Domain.Base;
using Conta.Domain.Enum;

namespace Conta.Domain.Entities
{
    public class Lancamento : EntidadeBase<Lancamento>
    {
        public string ContaDestino { get; set; }
        public string ContaOrigem { get; set; }
        public double  Valor { get; set; }        
                
        public override bool EstaConsistente()
        {
            RuleFor(x => x.ContaDestino)
               .NotEmpty().WithMessage("O campo ContaDestino deve ser preenchido")
               .Length(2, 50).WithMessage("O campo ContaDestino precisa ter entre 2 e 50 caracteres");

            RuleFor(x => x.ContaOrigem)
              .NotEmpty().WithMessage("O campo ContaOrigem deve ser preenchido")
              .Length(2, 50).WithMessage("O campo ContaOrigem precisa ter entre 2 e 50 caracteres");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O campo Valor precisa ser maior que zero.");

            
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
