using AutoMapper;
using Conta.Application.Interfaces;
using Conta.Application.Models;
using Conta.Application.ViewModels;
using Conta.Domain.Entities;
using Conta.Domain.Interfaces.IServices;
using Conta.Infra.Data.Interfaces;
using Conta.Application.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conta.Application.Services
{
    public class ApplicationLancamento : IApplicationLancamento
    {

        private readonly IServiceLancamento service;
        private readonly IServiceContaCorrente serviceConta;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ApplicationLancamento(IServiceLancamento _service,
                                     IServiceContaCorrente _serviceConta,
            IUnitOfWork _uow,
            IMapper _mapper)
        {
            service = _service;
            serviceConta = _serviceConta;
            uow = _uow;
            mapper = _mapper;
        }

        public RequestResult Add(LancamentoViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<LancamentoViewModel>(service.Add(mapper.Map<Lancamento>(entidade)));

                var contaOrigem = serviceConta.GetByConta(entidade.ContaOrigem);
                var contaDestino = serviceConta.GetByConta(entidade.ContaDestino);

                if(contaDestino == null  || contaOrigem == null)
                {
                    lista.Add("Conta de Origem ou Destino não localizadas!");
                    return new RequestResult(lista, entidade, StatusMensagem.Erro);
                }

                if (contaOrigem.Saldo < entidade.Valor)
                {
                    lista.Add("Conta de origem não possue saldo suficiente para está transação!");
                    return new RequestResult(lista, entidade, StatusMensagem.Erro);
                }

                contaDestino.Saldo += entidade.Valor;
                contaOrigem.Saldo -= entidade.Valor;

                var entidadeContaOrigem = serviceConta.Update(contaOrigem);
                if (entidadeContaOrigem.ValidationResult.Errors.Any()) return new RequestResult(entidadeContaOrigem.ValidationResult.Errors, entidadeContaOrigem, StatusMensagem.Erro);
                
                var entidadeContaDestino = serviceConta.Update(contaDestino);
                if (entidadeContaDestino.ValidationResult.Errors.Any()) return new RequestResult(entidadeContaDestino.ValidationResult.Errors, entidadeContaDestino, StatusMensagem.Erro);


                uow.Commit(entidade.ValidationResult);
                if (!entidade.ValidationResult.Errors.Any())
                {
                    lista.Add("Sucesso!");
                    return new RequestResult(lista, entidade, StatusMensagem.Ok);
                }
                else
                {
                    return new RequestResult(entidade.ValidationResult.Errors, entidade, StatusMensagem.Erro);
                }
            }
            catch (Exception ex)
            {
                lista.Add(ex.Message.ToString());
                return new RequestResult(lista, entidade, StatusMensagem.Erro);
            }
        }

        public RequestResult Update(LancamentoViewModel entidade)
        {
            var lista = new List<string>();
            try
            {                
                entidade = mapper.Map<LancamentoViewModel>(service.Update(mapper.Map<Lancamento>(entidade)));
                uow.Commit(entidade.ValidationResult);
                if (!entidade.ValidationResult.Errors.Any())
                {
                    lista.Add("Sucesso!");
                    return new RequestResult(lista, entidade, StatusMensagem.Ok);
                }
                else
                {
                    return new RequestResult(entidade.ValidationResult.Errors, entidade, StatusMensagem.Erro);
                }
            }
            catch (Exception ex)
            {
                lista.Add(ex.Message.ToString());
                return new RequestResult(lista, entidade, StatusMensagem.Erro);
            }
        }

        public RequestResult Remove(LancamentoViewModel entidade)
        {
            var lista = new List<string>();
            try
            {                
                entidade = mapper.Map<LancamentoViewModel>(service.Remove(mapper.Map<Lancamento>(entidade)));
                uow.Commit(entidade.ValidationResult);
                if (!entidade.ValidationResult.Errors.Any())
                {
                    lista.Add("Sucesso!");
                    return new RequestResult(lista, entidade, StatusMensagem.Ok);
                }
                else
                {
                    return new RequestResult(entidade.ValidationResult.Errors, entidade, StatusMensagem.Erro);
                }
            }
            catch (Exception ex)
            {
                lista.Add(ex.Message.ToString());
                return new RequestResult(lista, entidade, StatusMensagem.Erro);
            }
        }
        public LancamentoViewModel Find(long id)
        {
            return mapper.Map<LancamentoViewModel>(service.Find(id));
        }

        public IEnumerable<LancamentoViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<LancamentoViewModel>>(service.GetAll());
        }


        public void Dispose()
        {
            service.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
