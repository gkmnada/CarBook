namespace Application.Interfaces
{
    public interface IStatisticRepository
    {
        Task<int> GetCarCountAsync();
    }
}
