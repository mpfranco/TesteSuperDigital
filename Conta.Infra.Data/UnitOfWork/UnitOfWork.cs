using FluentValidation.Results;
using Conta.Infra.Data.Context;
using Conta.Infra.Data.Interfaces;
using System.Linq;

namespace Conta.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContaContext _contaContext;
        public UnitOfWork(DataBaseContaContext dnsContext)
        {
            _contaContext = dnsContext;
        }
        public void Commit(ValidationResult validation)
        {
            if (!validation.Errors.Any())
            {
                _contaContext.SaveChanges();
            }
        }
       
    }
}
