using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarFeature>> ListCarFeatureByCarIdAsync(string id)
        {
            var values = await _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarID == id).OrderBy(x => x.Feature.FeatureName).ToListAsync();
            return values;
        }
    }
}
