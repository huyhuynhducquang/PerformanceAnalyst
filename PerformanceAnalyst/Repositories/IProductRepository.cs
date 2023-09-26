using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
        Task<List<Product>> GetBySkuAsync(string sku);
        Task<Product?> GetByIdAsync(int id);
    }
}
