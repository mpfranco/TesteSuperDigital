using Conta.Application.ViewModels.Base;

namespace Conta.Application.ViewModels
{
    public class LancamentoViewModel : BaseViewModel
    {
        public string ContaDestino { get; set; }
        public string ContaOrigem { get; set; }
        public double Valor { get; set; }
        
    }
}
