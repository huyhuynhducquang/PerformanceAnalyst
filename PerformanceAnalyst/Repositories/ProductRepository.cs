using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Iphone 15", Sku = "IP15", SourceUrl = "", PriceElement = "span[@class='product-price']" },
            new Product { Id = 2, Name = "Iphone 15", Sku = "IP15", SourceUrl = "", PriceElement = "div[@class='price']" },
            new Product { Id = 3, Name = "Iphone 15", Sku = "IP15", SourceUrl = "", PriceElement = "div[@class='current-price']" },
            new Product { Id = 4, Name = "Macbook", Sku = "MB2023", SourceUrl = "", PriceElement = "span[@class='product-price']"},
            new Product { Id = 4, Name = "Macbook", Sku = "MB2023", SourceUrl = "", PriceElement = "div[@class='prices-best-price']"},
            new Product { Id = 4, Name = "Macbook", Sku = "MB2023", SourceUrl = "", PriceElement = "span[@class='final-price']"},
            new Product { Id = 5, Name = "IPad", Sku = "IPad2022", SourceUrl = "", PriceElement = "div[@class='price']" },
            new Product { Id = 5, Name = "IPad", Sku = "IPad2022", SourceUrl = "", PriceElement = "div[@class='price']" },
        };
        
        public Task<List<Product>> GetAsync()
        {
            return Task.FromResult(_products);
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(_ => _.Id == id));
        }

        public Task<List<Product>> GetBySkuAsync(string sku)
        {
            return Task.FromResult(_products
                .Where(_ => _.Sku == sku)
                .ToList());
        }
    }
}
