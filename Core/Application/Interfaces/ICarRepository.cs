using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> ListCarWithBrandAsync();
        Task<int> GetCarCountAsync();
    }
}
