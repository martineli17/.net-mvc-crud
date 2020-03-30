using Apresentation.Models.Pais;
using AutoMapper;
using Domain.DTO;

namespace Apresentation.AutoMapper
{
    public class PaisViewModelMapper : Profile
    {
        public PaisViewModelMapper()
        {
            CreateMap<PaisViewModelPost, PaisDTO>();
            CreateMap<PaisDTO, PaisViewModelGet>();
        }
    }
}
