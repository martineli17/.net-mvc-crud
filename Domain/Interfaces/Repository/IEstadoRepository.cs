using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IEstadoRepository : IBaseRepository<Estado>
    {
        Task<bool> Exists(string descricao, Guid idEstado);
    }
}
