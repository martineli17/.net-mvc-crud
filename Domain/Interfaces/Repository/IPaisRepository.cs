using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IPaisRepository : IBaseRepository<Pais>
    {
        Task<bool> Exists(string descricao);
    }
}
