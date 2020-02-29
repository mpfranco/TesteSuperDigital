using Conta.Infra.CrossCutting.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;


namespace Conta.Test
{
    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public DbFixture()
        {
            var services = new ServiceCollection();
            RegistersServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }
        private static void RegistersServices(IServiceCollection service)
        {
            service.AddSingleton<IMemoryCache>(new MemoryCache(new MemoryCacheOptions() { }));
            Bootstrap.RegisterServices(service);
        }
    }
}
