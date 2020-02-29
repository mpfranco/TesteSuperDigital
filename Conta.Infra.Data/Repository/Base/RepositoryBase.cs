using Conta.Domain.Base;
using Conta.Domain.Interfaces.IRepository.Base;
using Conta.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conta.Infra.Data.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntidadeBase<T>
    {
        protected readonly DataBaseContaContext contexto;
        protected DbSet<T> DbSet;
        public RepositoryBase(DataBaseContaContext _contexto)
        {
            contexto = _contexto;
            DbSet = contexto.Set<T>();
        }
        public T Add(T entidade)
        {
            DbSet.Add(entidade);
            return entidade;
        }

        public void Update(T entidade)
        {
            DbSet.Update(entidade);
        }

        public void Remove(T entidade)
        {
            DbSet.Remove(entidade);
        }
        public T Find(long Id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Dispose()
        { }
    }
}
