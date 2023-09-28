using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Dtos
{
    public class ProductComparisionDto
    {
        public string TimeToExecute { get; set; }
        public string Name { get; set; }
        public List<ProductPrice> Prices { get; set; }
    }
}
