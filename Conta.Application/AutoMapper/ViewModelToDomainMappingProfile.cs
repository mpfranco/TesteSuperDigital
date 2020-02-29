using AutoMapper;
using Conta.Application.ViewModels;
using Conta.Domain.Entities;
using System;
using System.Globalization;

namespace Conta.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
                .ForMember(to => to.DataAlteracao, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataAlteracao, CultureInfo.GetCultureInfo("pt-BR"))))
                .ForMember(to => to.DataInclusao, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataInclusao, CultureInfo.GetCultureInfo("pt-BR"))));


            CreateMap<ContaCorrenteViewModel, ContaCorrente>()
               .ForMember(to => to.DataAlteracao, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataAlteracao, CultureInfo.GetCultureInfo("pt-BR"))))
               .ForMember(to => to.DataInclusao, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataInclusao, CultureInfo.GetCultureInfo("pt-BR"))));

            CreateMap<LancamentoViewModel, Lancamento>()
               .ForMember(to => to.DataAlteracao, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataAlteracao, CultureInfo.GetCultureInfo("pt-BR"))))
               .ForMember(to => to.DataInclusao, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataInclusao, CultureInfo.GetCultureInfo("pt-BR"))));

        }
    }
}
