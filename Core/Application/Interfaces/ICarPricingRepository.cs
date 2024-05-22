using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> ListCarPricingWithCarAsync();
    }
}
