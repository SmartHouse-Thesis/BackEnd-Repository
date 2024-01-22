using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseRepo<T>
    {
        Task<IQueryable<T>> FindAllAsync(List<string> includes = null);
        Task<T> GetAsync(Guid id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
