using EComm_Store_Core.Entities;
using EComm_Store_Core.Specifications;

namespace EComm_Store_Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIDAsync(int id);
        Task<IReadOnlyList<T>> GetCollectionAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetCollectionAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}