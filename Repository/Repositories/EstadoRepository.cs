using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(ContextBase context) : base(context)
        {
        }
        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await Task.Run(() => _context.Estado.Include(e => e.Pais).ToList());
        }
        public async Task<bool> Exists(string descricao, Guid idPais)
        {
            return await Task.Run(() => _context.Estado.Any(c => c.Descricao.ToLower().Equals(descricao.Trim().ToLower()) && c.IdPais.Equals(idPais)));
        }
    }
}
