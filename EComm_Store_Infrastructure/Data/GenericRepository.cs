using EComm_Store_Core.Entities;
using EComm_Store_Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm_Store_Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetCollectionAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}