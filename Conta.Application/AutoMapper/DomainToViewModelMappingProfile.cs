using AutoMapper;
using Conta.Application.ViewModels;
using Conta.Domain.Entities;
using Conta.Infra.CrossCutting.Extensions;


namespace Conta.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile :Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()

               .ForMember(to => to.DataAlteracao, opt => opt.MapFrom(from => from.DataAlteracao.Formatado("{0:dd/MM/yyyy HH:mm}")))

               .ForMember(to => to.DataInclusao, opt => opt.MapFrom(from => from.DataInclusao.Formatado("{0:dd/MM/yyyy HH:mm}")));

            CreateMap<ContaCorrente, ContaCorrenteViewModel>()

               .ForMember(to => to.DataAlteracao, opt => opt.MapFrom(from => from.DataAlteracao.Formatado("{0:dd/MM/yyyy HH:mm}")))

               .ForMember(to => to.DataInclusao, opt => opt.MapFrom(from => from.DataInclusao.Formatado("{0:dd/MM/yyyy HH:mm}")));

            CreateMap<Lancamento, LancamentoViewModel>()

               .ForMember(to => to.DataAlteracao, opt => opt.MapFrom(from => from.DataAlteracao.Formatado("{0:dd/MM/yyyy HH:mm}")))

               .ForMember(to => to.DataInclusao, opt => opt.MapFrom(from => from.DataInclusao.Formatado("{0:dd/MM/yyyy HH:mm}")));

        }
    }
}
