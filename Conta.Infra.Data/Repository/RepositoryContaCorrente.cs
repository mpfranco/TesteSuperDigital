using Conta.Domain.Entities;
using Conta.Domain.Enum;
using Conta.Domain.Interfaces.IRepository;
using Conta.Infra.Data.Context;
using Conta.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Conta.Infra.Data.Repository
{
    public class RepositoryContaCorrente : RepositoryBase<ContaCorrente>, IRepositoryContaCorrente
    {
        public RepositoryContaCorrente(DataBaseContaContext context) : base(context)
        {

        }       

        public ContaCorrente GetByConta(string nrConta)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.NrConta == nrConta && x.Ativo == true);
        }
    }
}
