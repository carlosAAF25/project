using OnlineStore.Models;

namespace OnlineStore.Interfaces
{
    /// <summary>
    /// Abstraction for data operations related to products.
    /// </summary>
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
