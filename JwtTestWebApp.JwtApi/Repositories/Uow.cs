using JwtTestWebApp.JwtApi.Data.Contexts;

namespace JwtTestWebApp.JwtApi.Repositories
{
    public class Uow : IUow
    {
        private readonly JwtTestAuthContext _context;

        public Uow(JwtTestAuthContext context)
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
