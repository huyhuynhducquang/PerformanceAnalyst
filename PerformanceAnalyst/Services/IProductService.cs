using PerformanceAnalyst.Dtos;
using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Services
{
    public interface IProductService
    {
        List<Product> GetAsync();
        List<Product> GetByNameAsync(string name);
    }
}
