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


namespace Conta.Application.Services
{

    public class ApplicationContaCorrente : IApplicationContaCorrente
    {
        private readonly IServiceContaCorrente service;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ApplicationContaCorrente(IServiceContaCorrente _service,
            IUnitOfWork _uow,
            IMapper _mapper)
        {
            service = _service;
            uow = _uow;
            mapper = _mapper;
        }

        public RequestResult Add(ContaCorrenteViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<ContaCorrenteViewModel>(service.Add(mapper.Map<ContaCorrente>(entidade)));
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

        public RequestResult Update(ContaCorrenteViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<ContaCorrenteViewModel>(service.Update(mapper.Map<ContaCorrente>(entidade)));
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

        public RequestResult Remove(ContaCorrenteViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<ContaCorrenteViewModel>(service.Remove(mapper.Map<ContaCorrente>(entidade)));
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
        public ContaCorrenteViewModel Find(long id)
        {
            return mapper.Map<ContaCorrenteViewModel>(service.Find(id));
        }

        public IEnumerable<ContaCorrenteViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<ContaCorrenteViewModel>>(service.GetAll());
        }

        public ContaCorrenteViewModel GetByConta(string nrConta)
        {
            return mapper.Map<ContaCorrenteViewModel>(service.GetByConta(nrConta));
        }

        public void Dispose()
        {
            service.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }

}
