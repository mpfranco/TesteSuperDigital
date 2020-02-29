using Conta.Application.ViewModels.Base;


namespace Conta.Application.ViewModels
{
    public class ContaCorrenteViewModel : BaseViewModel
    {
        public string NrConta { get; set; }
        public int Digito { get; set; }
        public double Saldo { get; set; }
        public long IdCliente { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
