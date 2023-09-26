using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Iphone 15", Sku = "IP15", Source = Source.Cellphone, PriceElement = "18.800.000 VNĐ", Link ="https://cellphones.com.vn/iphone-15.html" },
            new Product { Id = 2, Name = "Iphone 15", Sku = "IP15", Source = Source.Thegioididong, PriceElement = "21.490.000 VNĐ", Link = "https://www.thegioididong.com/iphone-15-series?m=-1" },
            new Product { Id = 3, Name = "Iphone 15", Sku = "IP15", Source = Source.FPTStore, PriceElement = "22.990.000 VNĐ", Link = "https://fptshop.com.vn/dien-thoai/iphone-15" },
            new Product { Id = 4, Name = "Macbook", Sku = "MB2023", Source = Source.FPTStore, PriceElement = "34.199.000 VNĐ"},
            new Product { Id = 5, Name = "Macbook", Sku = "MB2023", Source = Source.Cellphone, PriceElement = "37.000.000 VNĐ"},
            new Product { Id = 6, Name = "Macbook", Sku = "MB2023", Source = Source.Thegioididong, PriceElement = "42.399.000 VNĐ"},
            new Product { Id = 7, Name = "IPad", Sku = "IPad2022", Source = Source.Thegioididong, PriceElement = "9.999.000 VNĐ" },
            new Product { Id = 8, Name = "IPad", Sku = "IPad2022", Source = Source.FPTStore, PriceElement = "12.000.000 VNĐ" },
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
