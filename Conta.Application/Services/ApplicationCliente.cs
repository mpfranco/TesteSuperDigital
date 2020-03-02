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
    public class ApplicationCliente : IApplicationCliente
    {
        private readonly IServiceCliente service;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ApplicationCliente(IServiceCliente _service,
            IUnitOfWork _uow,
            IMapper _mapper)
        {
            service = _service;
            uow = _uow;
            mapper = _mapper;
        }

        public RequestResult Add(ClienteViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<ClienteViewModel>(service.Add(mapper.Map<Cliente>(entidade)));
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

        public RequestResult Update(ClienteViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<ClienteViewModel>(service.Update(mapper.Map<Cliente>(entidade)));
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

        public RequestResult Remove(ClienteViewModel entidade)
        {
            var lista = new List<string>();
            try
            {
                entidade.DataInclusao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
                entidade = mapper.Map<ClienteViewModel>(service.Remove(mapper.Map<Cliente>(entidade)));
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
        public ClienteViewModel Find(long id)
        {
            return mapper.Map<ClienteViewModel>(service.Find(id));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<ClienteViewModel>>(service.GetAll());
        }


        public void Dispose()
        {
            service.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
