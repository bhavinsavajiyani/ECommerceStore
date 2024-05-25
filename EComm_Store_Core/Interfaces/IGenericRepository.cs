using EComm_Store_Core.Entities;

namespace EComm_Store_Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIDAsync(int id);
        Task<IReadOnlyList<T>> GetCollectionAsync();
    }
}