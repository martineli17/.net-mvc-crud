using Apresentation.Models.Estado;
using AutoMapper;
using Domain.DTO;

namespace Apresentation.AutoMapper
{
    public class EstadoViewModelMapper : Profile
    {
        public EstadoViewModelMapper()
        {
            CreateMap<EstadoViewModelPost, EstadoDTO>();
            CreateMap<EstadoViewModelPut, EstadoDTO>();
            CreateMap<EstadoDTO, EstadoViewModelGet>().ForMember(dest => dest.Pais, options => options.MapFrom(src => src.Pais.Descricao));
        }
    }
}
