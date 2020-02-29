using FluentValidation;
using Conta.Domain.Base;



namespace Conta.Domain.Entities
{
    public class ContaCorrente : EntidadeBase<ContaCorrente>
    {
        public string NrConta { get; set; }
        public int Digito { get; set; }
        public double Saldo { get; set; }
        public long IdCliente { get; set; }
        
        public override bool EstaConsistente()
        {
            RuleFor(x => x.NrConta)
                .NotEmpty().WithMessage("O campo NrConta deve ser preenchido")
                .Length(2, 50).WithMessage("O campo NrConta precisa ter entre 2 e 50 caracteres");

            RuleFor(x => x.IdCliente)
                .GreaterThan(0).WithMessage("O cliente precisa ser informado.");
            
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;

        }
    }
}
