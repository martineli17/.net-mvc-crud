using Domain.Entities;
using Domain.Interfaces.Repository;
using Repository.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public PaisRepository(ContextBase context) : base(context)
        {
        }

        public async Task<bool> Exists(string descricao)
        {
            return await Task.Run(() => _context.Pais.Any(c => c.Descricao.ToLower().Equals(descricao.Trim().ToLower())));
        }
    }
}
