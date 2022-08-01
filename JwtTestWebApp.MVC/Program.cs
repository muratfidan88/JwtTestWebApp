using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "JwtCookie";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.ExpireTimeSpan = TimeSpan.FromDays(10);
    opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
    opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
    opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");
});
builder.Services.AddControllersWithViews();




var app = builder.Build();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
