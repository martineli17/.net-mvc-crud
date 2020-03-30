using AutoMapper;
using Domain.DTO;
using Domain.Entities;

namespace Service.AutoMapper
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
        }
    }
}
