using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.Interfaces.IServices.Base
{
    public interface IServiceBase<T> : IDisposable
    {
        T Add(T entidade);
        T Remove(T entidade);
        T Find(long id);
        IEnumerable<T> GetAll();
        T Update(T entidade);
    }
}
