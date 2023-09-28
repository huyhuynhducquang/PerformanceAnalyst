namespace PerformanceAnalyst.Services
{
    public class PriceFetcherService : IPriceFetcherService
    {
        public async Task<string> GetPriceAsync(string source, string priceElement)
        {
            await Task.Delay(2000);
            return priceElement;
        }

        public async Task<string> GetStoreAsync(string source)
        {
            await Task.Delay(2000);
            return source;
        }
    }
}
