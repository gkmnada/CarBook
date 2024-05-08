namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> ListAsync();
        Task<T> GetAsync(Guid id);
        Task CreateAsnyc(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
