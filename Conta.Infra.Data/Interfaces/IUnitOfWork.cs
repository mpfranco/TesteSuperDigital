using FluentValidation.Results;

namespace Conta.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit(ValidationResult validation);
    }
}
