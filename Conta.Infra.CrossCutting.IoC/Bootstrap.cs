using AutoMapper;
using Conta.Application.AutoMapper;
using Conta.Application.Interfaces;
using Conta.Application.Services;
using Conta.Domain.Interfaces.IRepository;
using Conta.Domain.Interfaces.IServices;
using Conta.Domain.Services;
using Conta.Infra.Data.Context;
using Conta.Infra.Data.Interfaces;
using Conta.Infra.Data.Repository;
using Conta.Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Conta.Infra.CrossCutting.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Context
            services.AddScoped<DataBaseContaContext>();

            //Repository - the Dependecy injection
            services.AddScoped<IRepositoryCliente, RepositoryCliente>();
            services.AddScoped<IRepositoryContaCorrente, RepositoryContaCorrente>();
            services.AddScoped<IRepositoryLancamento, RepositoryLancamento>();

            //Servives the dependecy injection
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IServiceContaCorrente, ServiceContaCorrente>();
            services.AddScoped<IServiceLancamento, ServiceLancamento>();

            //Application the dependecy injection
            services.AddScoped<IApplicationCliente, ApplicationCliente>();
            services.AddScoped<IApplicationContaCorrente, ApplicationContaCorrente>();
            services.AddScoped<IApplicationLancamento, ApplicationLancamento>();
        }
    }
}
