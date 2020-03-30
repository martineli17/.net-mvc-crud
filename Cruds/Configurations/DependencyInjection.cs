using Crosscuting.Notification;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.Repositories;
using Repository.UnitOfWork;
using Service.Crud;
using Service.Validator.Base;
using Service.Validator.Interface;

namespace Apresentation.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Aplicacao
            services.AddScoped<ContextBase>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotify, Notify>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IExecuteValidation, ExecuteValidator>();
            #endregion

            #region Repositories
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            #endregion

            return services;
        }
    }
}
