using AutoMapper;
using Domain.DTO;
using Domain.Entities;

namespace Service.AutoMapper
{
    public class CidadeMapper : Profile
    {
        public CidadeMapper()
        {
            CreateMap<Cidade, CidadeDTO>().ReverseMap();
        }
    }
}
