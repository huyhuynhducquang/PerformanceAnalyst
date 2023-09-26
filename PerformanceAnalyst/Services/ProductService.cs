using PerformanceAnalyst.Dtos;
using PerformanceAnalyst.Models;
using PerformanceAnalyst.Repositories;

namespace PerformanceAnalyst.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAsync()
        {
            var product = await _productRepository.GetAsync();

            return product
                .GroupBy(_ => _.Sku)
                .Select(group => group.First())
                .ToList();
        }

        public async Task<ProductComparisionDto> GetProductDetailsAsync(string sku)
        {
            var products = await _productRepository.GetBySkuAsync(sku);

            if (products == null)
                throw new ArgumentException(nameof(sku));

            var prices = new List<ProductPrice>();

            foreach (var product in products)
            {
                var htmlContent = await FetchHtmlContentOfPageAsync(product.Link);
                var price = new ProductPrice()
                {
                    Price = await GetPriceAsync(htmlContent, product.PriceElement),
                    LogoUrl = await GetLogoUrlAsync(htmlContent),
                    Link = product.Link,
                    Store = product.Source.ToString(),
                };
                prices.Add(price);
            }
                    

            return new ProductComparisionDto()
            {
                Name = products[0].Name,
                Sku = products[0].Sku,
                Prices = prices.ToList()
            };
        }

        private Task<string> FetchHtmlContentOfPageAsync(string sourceUrl)
        {
            Task.Delay(5000).Wait();
            return Task.FromResult("");
        }

        private Task<string> GetPriceAsync(string htmlContent, string priceElement)
        {
            Task.Delay(1000);
            return Task.FromResult(priceElement);
        }

        private Task<string> GetLogoUrlAsync(string htmlContent)
        {
            Task.Delay(1000);
            return Task.FromResult("");
        }

    }
}
