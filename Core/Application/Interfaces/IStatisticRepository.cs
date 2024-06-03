namespace Application.Interfaces
{
    public interface IStatisticRepository
    {
        Task<int> GetCarCountAsync();
        Task<int> GetLocationCountAsync();
        Task<int> GetBrandCountAsync();
        Task<decimal> GetDailyAveragePricingAsync();
        Task<decimal> GetWeeklyAveragePricingAsync();
        Task<decimal> GetMonthlyAveragePricingAsync();
        Task<int> GetAutomaticTransmissionCarCountAsync();
        Task<int> GetManuelTransmissionCarCountAsync();
        Task<string> GetBrandNameByMostCarAsync();
        Task<string> GetCarByDailyMinPriceAsync();
        Task<string> GetCarByDailyMaxPriceAsync();
        Task<string> GetCarByWeeklyMinPriceAsync();
        Task<string> GetCarByWeeklyMaxPriceAsync();
        Task<string> GetCarByMonthlyMinPriceAsync();
        Task<string> GetCarByMonthlyMaxPriceAsync();
        Task<int> GetDieselFuelCarCountAsync();
        Task<int> GetGasolineFuelCarCountAsync();
        Task<int> GetElectricFuelCarCountAsync();
    }
}
