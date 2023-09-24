using Microsoft.AspNetCore.Mvc;
using PerformanceAnalyst.Services;

namespace PerformanceAnalyst.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAsync());
        }

        public async Task<IActionResult> Details(string sku)
        {
            var product = await _productService.GetProductDetailsAsync(sku);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
