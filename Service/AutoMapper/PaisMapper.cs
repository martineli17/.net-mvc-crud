using AutoMapper;
using Domain.DTO;
using Domain.Entities;

namespace Service.AutoMapper
{
    public class PaisMapper : Profile
    {
        public PaisMapper()
        {
            CreateMap<Pais, PaisDTO>().ReverseMap();
        }
    }
}
