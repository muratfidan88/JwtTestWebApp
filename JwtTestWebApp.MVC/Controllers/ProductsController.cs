using JwtTestWebApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace JwtTestWebApp.MVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetAll()
        {
            var token = HttpContext.User.FindFirst("Token").Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("http://localhost:5050/api/product/Products");
            if(responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<ProductModel>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return View(data);
            }
            return View(new List<ProductModel>());
        }
        public async Task<IActionResult> GetDetail(int id)
        {
            var token = HttpContext.User.FindFirst("Token").Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("http://localhost:5050/api/product/Products/" + id);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<ProductModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return View(data);
            }
            return NotFound();
        }
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel model)
        {
            var token = HttpContext.User.FindFirst("Token").Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var jsonData = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5050/api/product/Products", content);
            if (responseMessage.StatusCode == HttpStatusCode.Created)
                return RedirectToAction("GetAll");
            ModelState.AddModelError("", "Hata mesajı");
            return View(model);
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var token = HttpContext.User.FindFirst("Token").Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("http://localhost:5050/api/product/Products/" + id);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<ProductModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductModel model)
        {
            var token = HttpContext.User.FindFirst("Token").Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var jsonData = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5050/api/product/Products", content);
            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                return RedirectToAction("GetAll");
            ModelState.AddModelError("", "Hata mesajı");
            return View(model);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var token = HttpContext.User.FindFirst("Token").Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.DeleteAsync("http://localhost:5050/api/product/Products/"+id);
            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                return RedirectToAction("GetAll");
            return NotFound();
        }
    }
}
