using Conta.Application.Interfaces.Base;
using Conta.Application.ViewModels;

namespace Conta.Application.Interfaces
{
    public interface IApplicationContaCorrente : IApplicationBase<ContaCorrenteViewModel>
    {
        ContaCorrenteViewModel GetByConta(string nrConta);
    }
}
