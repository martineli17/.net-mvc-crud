using Apresentation.Models.Paciente;
using AutoMapper;
using Domain.DTO;

namespace Apresentation.AutoMapper
{
    public class PacienteViewModelMapper : Profile
    {
        public PacienteViewModelMapper()
        {
            CreateMap<PacienteViewModelPost, PacienteDTO>()
                .ForMember(dest => dest.Cpf, options => options.MapFrom((src, dest) => src.Cpf = src.Cpf?.Replace(".", "").Replace("-","")));
            CreateMap<PacienteViewModelPut, PacienteDTO>()
                .ForMember(dest => dest.Cpf, options => options.MapFrom((src, dest) => src.Cpf = src.Cpf?.Replace(".", "").Replace("-","")));
            CreateMap<PacienteDTO, PacienteViewModelGet>()
                .ForMember(dest => dest.Estado, options => options.MapFrom(src => src.Estado.Descricao))
                .ForMember(dest => dest.Cidade, options => options.MapFrom(src => src.Cidade.Descricao))
                .ForMember(dest => dest.Pais, options => options.MapFrom(src => src.Pais.Descricao))
                .ForMember(dest => dest.Cpf, options => options.MapFrom((src, dest) => dest.Cpf = $"{src.Cpf?.Substring(0, 3)}.{src.Cpf?.Substring(3, 3)}.{src.Cpf?.Substring(6, 3)}-{src.Cpf?.Substring(9, 2)}"));
        }
    }
}
