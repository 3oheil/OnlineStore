using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Repositories;

namespace OnlineStore.Infrastructure.Persistence
{
    public class EfCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly OnlineStoreDbContext _context;

        public EfCoreRepository(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
