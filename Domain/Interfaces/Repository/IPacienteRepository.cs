using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Task<bool> Exists(string cpf);
    }
}
