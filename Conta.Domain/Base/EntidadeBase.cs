using FluentValidation;
using FluentValidation.Results;
using System;

namespace Conta.Domain.Base
{
    public abstract class EntidadeBase<T> : AbstractValidator<T> where T : EntidadeBase<T>
    {
        public long Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public long UsuarioInclusaoId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public long UsuarioAlteracaoId { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        public EntidadeBase()
        {

            DataAlteracao = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public abstract bool EstaConsistente();

    }
}
