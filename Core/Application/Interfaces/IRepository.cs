using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> ListAsync();
        Task<T> GetAsync(string id);
        Task CreateAsnyc(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
