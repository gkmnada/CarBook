using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface ICarRentalRepository
    {
        Task<List<CarRental>> GetByFilterAsync(Expression<Func<CarRental, bool>> filter);
    }
}
