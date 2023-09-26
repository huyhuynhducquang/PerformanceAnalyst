namespace PerformanceAnalyst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public Source Source { get; set; }
        public string Link { get; set; }
        public string PriceElement { get; set; }
    }
}
