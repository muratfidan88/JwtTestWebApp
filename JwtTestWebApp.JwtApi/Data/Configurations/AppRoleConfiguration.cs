using JwtTestWebApp.JwtApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtTestWebApp.JwtApi.Data.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole { Id = 1, Defination = "Admin" });
            builder.HasData(new AppRole { Id = 2, Defination = "Member" });
        }
    }
}
