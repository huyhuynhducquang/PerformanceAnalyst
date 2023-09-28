namespace PerformanceAnalyst.Services
{
    public interface IPriceFetcherService
    {
        Task<string> GetPriceAsync(string source, string priceElement);
        Task<string> GetStoreAsync(string source);
    }
}
