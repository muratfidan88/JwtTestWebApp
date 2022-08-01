using JwtTestWebApp.JwtApi.Data.Configurations;
using JwtTestWebApp.JwtApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtTestWebApp.JwtApi.Data.Contexts
{
    public class JwtTestAuthContext : DbContext
    {
        public JwtTestAuthContext(DbContextOptions<JwtTestAuthContext> options):base(options)
        {

        }
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
