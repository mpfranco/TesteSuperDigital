using Conta.Domain.Entities;
using Conta.Domain.Interfaces.IRepository;
using Conta.Infra.Data.Context;
using Conta.Infra.Data.Repository.Base;

namespace Conta.Infra.Data.Repository
{
    public class RepositoryLancamento : RepositoryBase<Lancamento>, IRepositoryLancamento
    {
        public RepositoryLancamento(DataBaseContaContext context) : base(context)
        {

        }

    }
}
