using JwtTestWebApp.JwtApi.Data.Contexts;
using JwtTestWebApp.JwtApi.Repositories;
using JwtTestWebApp.JwtApi.Tools.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<JwtTestAuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddScoped<IUow, Uow>();

builder.Services.AddControllers();

// Jwt register ve config burda bu þekilde yapýlýyor.
// JwtTokenSettings classýnda const proplar oluþturduk. Bu proplardaki deðerleri kullanarak buraya verdik ama direkt elle de 
// yazabilirdik. Class üzerinden hareket edersek daha okunaklý olur.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = JwtTokenSettings.Audience,
        ValidIssuer = JwtTokenSettings.Issuer,
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key)),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("GlobalCors", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();
app.UseCors("GlobalCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
