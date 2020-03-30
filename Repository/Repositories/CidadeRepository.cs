using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ContextBase context) : base(context)
        {
          
        }

        public override async Task<IEnumerable<Cidade>> GetAllAsync()
        {
            return await Task.Run(() => _context.Cidade.Include(e => e.Estado).Include(e => e.Pacientes).ToList());
        }

        public async Task<bool> Exists(string descricao, Guid idEstado)
        {
            return await Task.Run(() => _context.Cidade.Any(c => c.Descricao.ToLower().Equals(descricao.Trim().ToLower()) && c.IdEstado.Equals(idEstado)));
        }
    }
}
