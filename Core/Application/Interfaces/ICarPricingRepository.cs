using Application.Features.Mediator.Results.CarPricingResults;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> ListCarPricingWithCarAsync();
        Task<List<CarPricing>> ListCarPricingWithCarRentalAsync(Expression<Func<CarRental, bool>> filter);
        Task<List<GetCarPricingWithPeriodQueryResult>> ListCarPricingWithPeriodAsync();
    }
}
