using AutoMapper;
using Domain.DTO;
using Domain.Entities;

namespace Service.AutoMapper
{
    public class EstadoMapper : Profile
    {
        public EstadoMapper()
        {
            CreateMap<Estado, EstadoDTO>().ReverseMap();
        }
    }
}
