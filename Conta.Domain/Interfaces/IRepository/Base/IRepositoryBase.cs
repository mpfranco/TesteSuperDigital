using System;
using System.Collections.Generic;

namespace Conta.Domain.Interfaces.IRepository.Base
{
    public interface IRepositoryBase<T> : IDisposable
    {
        T Add(T entidade);
        void Remove(T entidade);
        T Find(long Id);
        IEnumerable<T> GetAll();
        void Update(T entidade);
        new void Dispose();
    }
}
