using JwtTestWebApp.JwtApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtTestWebApp.JwtApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtTestAuthContext _context;

        public Repository(JwtTestAuthContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
