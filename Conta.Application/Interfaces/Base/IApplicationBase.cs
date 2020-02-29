using Conta.Application.Models;
using System;
using System.Collections.Generic;

namespace Conta.Application.Interfaces.Base
{
    public interface IApplicationBase<T> : IDisposable
    {
        RequestResult Add(T entidade);
        RequestResult Remove(T entidade);
        T Find(long id);
        IEnumerable<T> GetAll();
        RequestResult Update(T entidade);
    }
}
