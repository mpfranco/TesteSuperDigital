﻿using Conta.Domain.Entities;
using Conta.Domain.Enum;
using Conta.Domain.Interfaces.IServices.Base;

namespace Conta.Domain.Interfaces.IServices
{
    public interface IServiceContaCorrente : IServiceBase<ContaCorrente>
    {
        ContaCorrente GetByConta(string nrConta);
    }
}
