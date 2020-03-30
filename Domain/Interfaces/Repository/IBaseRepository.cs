using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(Guid id);
        Task<T> GetIdAsync(Guid id);
        Task<IEnumerable<T>> GetWithQueryAsync(Func<T, bool> func);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
