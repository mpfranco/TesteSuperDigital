using Conta.Application.Interfaces;
using Conta.Application.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace Conta.Test.Crud
{
    public class ClientesCrud : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;
        private readonly IApplicationCliente app;

        public ClientesCrud(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
            app = ServiceProvide.GetService<IApplicationCliente>();
        }

        [Fact]
        public void Insert()
        {
            var clienteViewModel = new ClienteViewModel
            {

                Ativo = true,
                CPF = "31035867877",
                DataInclusao = System.DateTime.Now.ToString("yyyMMdd"),
                NmCliente = "Michel Platini Venancio Franco",
                DataAlteracao = "29/05/2019 08:00",                
                UsuarioAlteracaoId = 1,
                UsuarioInclusaoId = 1
            };

            var requestResult = app.Add(clienteViewModel);

            Assert.True(requestResult.Mensagens.Any(), (requestResult.Mensagens.Any() ? requestResult.Mensagens[0] : "Sucesso"));
            
        }

        [Fact]
        public void Update()
        {
            var clienteViewModel = new ClienteViewModel
            {
                Id = 1,
                Ativo = true,
                CPF = "31035867877",
                DataInclusao = System.DateTime.Now.ToString("yyyMMdd"),
                NmCliente = "Michel Platini Venancio Franco TESTE",
                DataAlteracao = "29/05/2019 08:00",
                UsuarioAlteracaoId = 1,
                UsuarioInclusaoId = 1
            };

            var cliente = app.Update(clienteViewModel);

            Assert.True(cliente.Mensagens.Any(), (cliente.Mensagens.Any() ? cliente.Mensagens[0] : "Sucesso"));
        }

        [Fact]
        public void Get()
        {
            var clientes = app.GetAll();

            Assert.True(clientes.Any());
        }

        [Fact]
        public void GetId()
        {
            var cliente = app.Find(1);
            Assert.NotNull(cliente);
        }
    }
}
