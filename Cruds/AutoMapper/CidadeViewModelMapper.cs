using Apresentation.Models.Cidade;
using AutoMapper;
using Domain.DTO;

namespace Apresentation.AutoMapper
{
    public class CidadeViewModelMapper : Profile
    {
        public CidadeViewModelMapper()
        {
            CreateMap<CidadeViewModelPost, CidadeDTO>();
            CreateMap<CidadeViewModelPut, CidadeDTO>();
            CreateMap<CidadeDTO, CidadeViewModelGet>().ForMember(dest => dest.Estado, options => options.MapFrom(src => src.Estado.Descricao));
        }
    }
}
