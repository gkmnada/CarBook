using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> ListCarPricingByCarAsync(string id)
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).Where(x => x.CarID == id).OrderBy(x => x.Amount).ToListAsync();
            return values;
        }

        public async Task<List<CarPricing>> ListCarPricingWithCarAsync()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).Where(x => x.PricingID == "a1bba709-1ca4-42f2-820c-3d7687b99c59").OrderBy(x => x.Amount).ToListAsync();
            return values;
        }

        public async Task<List<CarPricing>> ListCarPricingWithCarRentalAsync(Expression<Func<CarRental, bool>> filter)
        {
            var carRental = _context.CarRentals.Where(filter).Select(x => x.CarID).Distinct();

            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).Where(x => x.PricingID == "a1bba709-1ca4-42f2-820c-3d7687b99c59" && carRental.Contains(x.CarID)).OrderBy(x => x.Amount).ToListAsync();
            return values;
        }

        public async Task<List<GetCarPricingWithPeriodQueryResult>> ListCarPricingWithPeriodAsync()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).GroupBy(x => new { x.Car.Brand.BrandName, x.Car.Model, x.Car.Image, x.CarID })
                .Select(x => new GetCarPricingWithPeriodQueryResult
                {
                    CarID = x.Key.CarID,
                    Model = x.Key.BrandName + " " + x.Key.Model,
                    Image = x.Key.Image,
                    DailyAmount = x.Where(z => z.Pricing.Name == "Günlük").Sum(y => y.Amount),
                    WeeklyAmount = x.Where(z => z.Pricing.Name == "Haftalık").Sum(y => y.Amount),
                    MonthlyAmount = x.Where(z => z.Pricing.Name == "Aylık").Sum(y => y.Amount)
                }).ToListAsync();

            return values;
        }
    }
}
