namespace Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<int> GetReviewCountByCarAsync(string id);
    }
}
