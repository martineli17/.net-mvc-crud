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
    public class BaseRepository<T>  : IBaseRepository<T> where T : class, new()
    {
        protected readonly ContextBase _context;
        public BaseRepository(ContextBase context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<T>().ToList());
        }

        public async Task<T> GetIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetWithQueryAsync(Func<T, bool> func)
        {
            return await Task.Run(() => _context.Set<T>().Where(func));
        }

        public async Task RemoveAsync(Guid id)
        {
            await Task.Run(async () => _context.Set<T>().Remove(await GetIdAsync(id)));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Entry(entity).State = EntityState.Modified);
        }
    }
}
