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
    }
}
