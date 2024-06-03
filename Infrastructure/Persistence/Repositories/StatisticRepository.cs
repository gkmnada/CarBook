using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetAutomaticTransmissionCarCountAsync()
        {
            var value = await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
            return value;
        }

        public async Task<int> GetBrandCountAsync()
        {
            var value = await _context.Brands.CountAsync();
            return value;
        }

        public async Task<string> GetBrandNameByMostCarAsync()
        {
            var value = await _context.Cars.Join(_context.Brands, x => x.BrandID, y => y.BrandID, (x, y) => new { x, y }).GroupBy(x => x.y.BrandName).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefaultAsync();
            return value;
        }

        public async Task<string> GetCarByDailyMaxPriceAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).MaxAsync(x => x.Amount);
            var model = await _context.CarPricings.Where(x => x.PricingID == id && x.Amount == value).Join(_context.Cars, x => x.CarID, y => y.CarID, (x, y) => new { x, y }).Select(x => x.y.Model).FirstOrDefaultAsync();
            return model;
        }

        public async Task<string> GetCarByDailyMinPriceAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).MinAsync(x => x.Amount);
            var model = await _context.CarPricings.Where(x => x.PricingID == id && x.Amount == value).Join(_context.Cars, x => x.CarID, y => y.CarID, (x, y) => new { x, y }).Select(x => x.y.Model).FirstOrDefaultAsync();
            return model;
        }

        public async Task<string> GetCarByMonthlyMaxPriceAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).MaxAsync(x => x.Amount);
            var model = await _context.CarPricings.Where(x => x.PricingID == id && x.Amount == value).Join(_context.Cars, x => x.CarID, y => y.CarID, (x, y) => new { x, y }).Select(x => x.y.Model).FirstOrDefaultAsync();
            return model;
        }

        public async Task<string> GetCarByMonthlyMinPriceAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).MinAsync(x => x.Amount);
            var model = await _context.CarPricings.Where(x => x.PricingID == id && x.Amount == value).Join(_context.Cars, x => x.CarID, y => y.CarID, (x, y) => new { x, y }).Select(x => x.y.Model).FirstOrDefaultAsync();
            return model;
        }

        public async Task<string> GetCarByWeeklyMaxPriceAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).MaxAsync(x => x.Amount);
            var model = await _context.CarPricings.Where(x => x.PricingID == id && x.Amount == value).Join(_context.Cars, x => x.CarID, y => y.CarID, (x, y) => new { x, y }).Select(x => x.y.Model).FirstOrDefaultAsync();
            return model;
        }

        public async Task<string> GetCarByWeeklyMinPriceAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).MinAsync(x => x.Amount);
            var model = await _context.CarPricings.Where(x => x.PricingID == id && x.Amount == value).Join(_context.Cars, x => x.CarID, y => y.CarID, (x, y) => new { x, y }).Select(x => x.y.Model).FirstOrDefaultAsync();
            return model;
        }

        public async Task<int> GetCarCountAsync()
        {
            var value = await _context.Cars.CountAsync();
            return value;
        }

        public async Task<decimal> GetDailyAveragePricingAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<int> GetDieselFuelCarCountAsync()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Dizel").CountAsync();
            return value;
        }

        public async Task<int> GetElectricFuelCarCountAsync()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Elektrikli").CountAsync();
            return value;
        }

        public async Task<int> GetGasolineFuelCarCountAsync()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Benzin").CountAsync();
            return value;
        }

        public async Task<int> GetLocationCountAsync()
        {
            var value = await _context.Locations.CountAsync();
            return value;
        }

        public async Task<int> GetManuelTransmissionCarCountAsync()
        {
            var value = await _context.Cars.Where(x => x.Transmission == "Manuel").CountAsync();
            return value;
        }

        public async Task<decimal> GetMonthlyAveragePricingAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<decimal> GetWeeklyAveragePricingAsync()
        {
            string id = await _context.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }
    }
}
