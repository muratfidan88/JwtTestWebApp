using JwtTestWebApp.ProductApi.Data.Configurations;
using JwtTestWebApp.ProductApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtTestWebApp.ProductApi.Data.Contexts
{
    public class JwtTestProductContext : DbContext
    {
        public JwtTestProductContext(DbContextOptions<JwtTestProductContext> options):base(options)
        {

        }
        public DbSet<Product> Products => this.Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
