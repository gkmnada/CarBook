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

        public async Task<int> GetCarCountAsync()
        {
            var value = await _context.Cars.CountAsync();
            return value;
        }
    }
}
