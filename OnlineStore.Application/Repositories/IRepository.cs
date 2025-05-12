using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task SaveChangesAsync();
    }
}
