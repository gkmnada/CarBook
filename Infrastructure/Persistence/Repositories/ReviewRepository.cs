using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetReviewCountByCarAsync(string id)
        {
            var values = await _context.Reviews.Where(x => x.CarID == id).CountAsync();
            return values;
        }
    }
}
