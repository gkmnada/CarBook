using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly CarBookContext _context;

        public CarRentalRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarRental>> GetByFilterAsync(Expression<Func<CarRental, bool>> filter)
        {
            var values = await _context.CarRentals.Include(x => x.Car).ThenInclude(x => x.Brand).Where(filter).ToListAsync();
            return values;
        }
    }
}
