using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Dtos
{
    public class ProductComparisionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public List<ProductPrice> Prices { get; set; }
    }
}
