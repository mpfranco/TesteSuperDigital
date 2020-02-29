using Conta.Domain.Entities;
using Conta.Domain.Enum;
using Conta.Domain.Interfaces.IRepository;
using Conta.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.Services
{
    public class ServiceContaCorrente : IServiceContaCorrente
    {
        private readonly IRepositoryContaCorrente repository;

        public ServiceContaCorrente(IRepositoryContaCorrente _repository)
        {
            repository = _repository;
        }
        public ContaCorrente Add(ContaCorrente entidade)
        {
            return repository.Add(entidade);
        }

        public ContaCorrente Update(ContaCorrente entidade)
        {
            repository.Update(entidade);
            return entidade;
        }
        public ContaCorrente Remove(ContaCorrente entidade)
        {
            repository.Remove(entidade);
            return entidade;
        }

        public ContaCorrente Find(long id)
        {
            return repository.Find(id);
        }

        public IEnumerable<ContaCorrente> GetAll()
        {
            return repository.GetAll();
        }


        public ContaCorrente GetByConta(string nrConta)
        {
            return repository.GetByConta(nrConta);
        }


        public void Dispose()
        {
            repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
