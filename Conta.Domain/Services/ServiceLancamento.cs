using Conta.Domain.Entities;
using Conta.Domain.Interfaces.IRepository;
using Conta.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;


namespace Conta.Domain.Services
{
    public class ServiceLancamento : IServiceLancamento
    {
        private readonly IRepositoryLancamento repository;

        public ServiceLancamento(IRepositoryLancamento _repository)
        {
            repository = _repository;
        }

        public Lancamento Add(Lancamento entidade)
        {
           return repository.Add(entidade);
        }
        public Lancamento Update(Lancamento entidade)
        {
            repository.Update(entidade);
            return entidade;
        }
        public Lancamento Remove(Lancamento entidade)
        {
            repository.Remove(entidade);
            return entidade;
        }
        public Lancamento Find(long id)
        {
            return repository.Find(id);
           
        }

        public IEnumerable<Lancamento> GetAll()
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
