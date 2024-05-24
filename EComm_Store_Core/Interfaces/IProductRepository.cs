using EComm_Store_Core.Entities;

namespace EComm_Store_Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIDAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}