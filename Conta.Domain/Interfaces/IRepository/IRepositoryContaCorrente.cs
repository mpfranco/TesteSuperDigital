using Conta.Domain.Entities;
using Conta.Domain.Enum;
using Conta.Domain.Interfaces.IRepository.Base;

namespace Conta.Domain.Interfaces.IRepository
{
    public interface IRepositoryContaCorrente : IRepositoryBase<ContaCorrente>
    {        
        ContaCorrente GetByConta(string nrConta);
    }
}
