using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<Car> GetCarWithBrandAsync(string id)
        {
            var values = await _context.Cars.Include(x => x.Brand).Where(x => x.CarID == id).FirstOrDefaultAsync();
            return values;
        }

        public async Task<List<Car>> ListCarWithBrandAsync()
        {
            var values = await _context.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }
    }
}
