using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<bool> Exists(string descricao, Guid idEstado);
    }
}
