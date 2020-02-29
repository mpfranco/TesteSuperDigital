using Conta.Domain.Interfaces.IRepository;
using Conta.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Conta.Test.Injecao
{
    public class TestDependencyInjection : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvide;

        public TestDependencyInjection(DbFixture fixture)
        {
            _serviceProvide = fixture.ServiceProvider;
        }

        [Fact]
        public void TestDependencyInjectionContext()
        {
            var context = _serviceProvide.GetService<DataBaseContaContext>();
            Assert.NotNull(context);
        }

        [Fact]
        public void TestDependencyRepositoryCliente()
        {
            var context = _serviceProvide.GetService<IRepositoryCliente>();
            Assert.NotNull(context);
        }

        [Fact]
        public void TestDependencyRepositoryContaCorrente()
        {
            var context = _serviceProvide.GetService<IRepositoryContaCorrente>();
            Assert.NotNull(context);
        }

        [Fact]
        public void TestDependencyRepositoryLancamento()
        {
            var context = _serviceProvide.GetService<IRepositoryLancamento>();
            Assert.NotNull(context);
        }
    }
}
