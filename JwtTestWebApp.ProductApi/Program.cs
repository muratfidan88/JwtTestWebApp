using JwtTestWebApp.ProductApi.Data.Contexts;
using JwtTestWebApp.ProductApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddDbContext<JwtTestProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = "http://localhost",
        ValidIssuer = "http://localhost",
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("muratmuratmurat1*")),
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

builder.Services.AddControllers();

var app = builder.Build();


app.UseCors("GlobalCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
