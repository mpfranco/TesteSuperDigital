using Conta.Domain.Entities;
using Conta.Domain.Interfaces.IRepository;
using Conta.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;


namespace Conta.Domain.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IRepositoryCliente repository;
        public ServiceCliente(IRepositoryCliente _repository)
        {
            repository = _repository;
        }
        public Cliente Add(Cliente entidade)
        {
            return repository.Add(entidade);
        }

        public Cliente Update(Cliente entidade)
        {
            repository.Update(entidade);
            return entidade;
        }
        public Cliente Remove(Cliente entidade)
        {
            repository.Update(entidade);
            return entidade;
        }
        public Cliente Find(long id)
        {
            return repository.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return repository.GetAll();
        }
               
        public void Dispose()
        {
            repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
