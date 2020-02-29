using Conta.Application.Interfaces;
using Conta.Application.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace Conta.Test.Crud
{
    public class ContaCorrenteCrud : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;
        private readonly IApplicationContaCorrente app;

        public ContaCorrenteCrud(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
            app = ServiceProvide.GetService<IApplicationContaCorrente>();
        }

        [Fact]
        public void Insert()
        {
            var contaCorrenteViewModel = new ContaCorrenteViewModel
            {
                Ativo = true,
                Saldo = 0,
                DataInclusao = System.DateTime.Now.ToString("yyyMMdd"),
                NrConta = "7654321",
                Digito = 1,                
                IdCliente = 2,                
                UsuarioAlteracaoId = 1,
                UsuarioInclusaoId = 1
            };

            var requestResult = app.Add(contaCorrenteViewModel);

            Assert.True(requestResult.Mensagens.Any(), (requestResult.Mensagens.Any() ? requestResult.Mensagens[0] : "Sucesso"));

        }

        [Fact]
        public void Update()
        {
            var contaCorrenteViewModel = new ContaCorrenteViewModel
            {
                Id = 1,
                Ativo = true,
                Saldo = 100,
                DataInclusao = System.DateTime.Now.ToString("yyyMMdd"),
                NrConta = "1234567",
                Digito = 1,
                IdCliente = 1,
                UsuarioAlteracaoId = 1,
                UsuarioInclusaoId = 1
            };

            var requestResult = app.Update(contaCorrenteViewModel);

            Assert.True(requestResult.Mensagens.Any(), (requestResult.Mensagens.Any() ? requestResult.Mensagens[0] : "Sucesso"));
        }

        [Fact]
        public void Get()
        {
            var lancamentos = app.GetAll();

            Assert.True(lancamentos.Any());
        }

        [Fact]
        public void GetId()
        {
            var lancamento = app.Find(1);
            Assert.NotNull(lancamento);
        }
    }
}

