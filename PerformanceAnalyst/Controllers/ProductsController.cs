using Microsoft.AspNetCore.Mvc;
using PerformanceAnalyst.Dtos;
using PerformanceAnalyst.Models;
using PerformanceAnalyst.Services;

namespace PerformanceAnalyst.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IPriceFetcherService _priceFetcherService;

        public ProductsController(IProductService productService, IPriceFetcherService priceFetcherService)
        {
            _productService = productService;
            _priceFetcherService = priceFetcherService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAsync());
        }

        public async Task<IActionResult> Details(string name)
        {
            var startTime = DateTime.Now;
            var products = _productService.GetByNameAsync(name);

            var prices = new List<ProductPrice>();

            foreach (var product in products)
            {
                prices.Add(new ProductPrice()
                {
                    Store = await _priceFetcherService.GetStoreAsync(product.Source),
                    Price = await _priceFetcherService.GetPriceAsync(product.Source, product.PriceElement)
                });
            }
            var endTime = DateTime.Now;

            return View(new ProductComparisionDto
            {
                Name = name,
                Prices = prices,
                TimeToExecute = (endTime - startTime).ToString()
            });
        }
    }
}
