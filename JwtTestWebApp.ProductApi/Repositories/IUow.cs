namespace JwtTestWebApp.ProductApi.Repositories
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChangesAsync();
    }
}
