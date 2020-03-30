using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> AddAsync(T entityDTO);
        Task<bool> UpdateAsync(T entityDTO);
        Task<bool> RemoveAsync(Guid id);
        Task<T> GetIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
