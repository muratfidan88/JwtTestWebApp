using JwtTestWebApp.ProductApi.Data.Contexts;

namespace JwtTestWebApp.ProductApi.Repositories
{
    public class Uow : IUow
    {
        private readonly JwtTestProductContext _context;

        public Uow(JwtTestProductContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
