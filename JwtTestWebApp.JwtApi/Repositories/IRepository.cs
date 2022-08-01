using System.Linq.Expressions;

namespace JwtTestWebApp.JwtApi.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
        void Delete(T entity);
    }
}
