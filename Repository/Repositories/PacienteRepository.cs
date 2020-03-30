using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ContextBase context) : base(context)
        {
        }

        public override async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await Task.Run(() => _context.Paciente.Include(p => p.Estado).Include(e => e.Cidade).Include(p => p.Pais).ToList());
        }

        public async Task<bool> Exists(string cpf)
        {
            return await Task.Run(() => _context.Paciente.Any(p => p.Cpf.Equals(cpf)));
        }
    }
}
