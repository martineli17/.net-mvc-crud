using Apresentation.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Service.AutoMapper;

namespace Apresentation.Configurations
{
    public static class AutoMapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PacienteMapper());
                mc.AddProfile(new EstadoMapper());
                mc.AddProfile(new PaisMapper());
                mc.AddProfile(new CidadeMapper());
                mc.AddProfile(new PaisViewModelMapper());
                mc.AddProfile(new EstadoViewModelMapper());
                mc.AddProfile(new CidadeViewModelMapper());
                mc.AddProfile(new PacienteViewModelMapper());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
