using PerformanceAnalyst.Dtos;
using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAsync();

        Task<ProductComparisionDto> GetProductDetailsAsync(string sku);
    }
}
