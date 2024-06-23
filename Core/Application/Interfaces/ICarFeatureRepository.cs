using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> ListCarFeatureByCarIdAsync(string id);
    }
}
