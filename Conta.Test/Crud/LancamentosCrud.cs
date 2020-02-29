using Conta.Application.Interfaces;
using Conta.Application.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace Conta.Test.Crud
{
    public class LancamentosCrud : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;
        private readonly IApplicationLancamento app;

        public LancamentosCrud(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
            app = ServiceProvide.GetService<IApplicationLancamento>();
        }

        [Fact]
        public void Insert()
        {
            var lancamentoViewModel = new LancamentoViewModel
            {
                Ativo = true,
                Valor = 4,
                DataInclusao = System.DateTime.Now.ToString("yyyMMdd"),
                ContaDestino = "1234567",
                ContaOrigem = "7654321",                
                UsuarioAlteracaoId = 1,
                UsuarioInclusaoId = 1
            };

            var requestResult = app.Add(lancamentoViewModel);

            Assert.True(requestResult.Mensagens.Any(), (requestResult.Mensagens.Any() ? requestResult.Mensagens[0] : "Sucesso"));

        }

        [Fact]
        public void Update()
        {
            var lancamentoViewModel = new LancamentoViewModel
            {
                Ativo = true,
                Valor = 1000,
                DataInclusao = System.DateTime.Now.ToString("yyyMMdd"),
                ContaDestino = "1234567",
                ContaOrigem = "7654321",
                UsuarioAlteracaoId = 1,
                UsuarioInclusaoId = 1
            };

            var requestResult = app.Update(lancamentoViewModel);

            Assert.True(requestResult.Mensagens.Any(), (requestResult.Mensagens.Any() ? requestResult.Mensagens[0] : "Sucesso"));
        }

        [Fact]
        public void Get()
        {
            var lancamentos = app.GetAll();

            Assert.True(lancamentos.Count() > 0);
        }

        [Fact]
        public void GetId()
        {
            var lancamento = app.Find(1);
            Assert.NotNull(lancamento);
        }
    }
}
