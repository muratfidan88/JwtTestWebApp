using JwtTestWebApp.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace JwtTestWebApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SignUp()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5050/api/jwt/Auth/SignUp", content);
            if (responseMessage.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("SignIn");
            }
            ModelState.AddModelError("", "Bu kullanıcı adı ile daha önceden kayıt yapılmış.");
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5050/api/jwt/Auth", content);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var token = await responseMessage.Content.ReadAsStringAsync();
                var tokenData = JsonSerializer.Deserialize<TokenModel>(token, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                var claims = new List<Claim>();
                claims.Add(new Claim("Token", tokenData.Token));
                var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("GetAll","Products");
            }
            ModelState.AddModelError("", "Kullanıcı adı ya da şifre hatalı.");
            return View(model);
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
