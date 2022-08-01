using JwtTestWebApp.ProductApi.Data.Entities;
using JwtTestWebApp.ProductApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTestWebApp.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IUow _uow;

        public ProductsController(IUow uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _uow.GetRepository<Product>().GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _uow.GetRepository<Product>().GetByIdAsync(id);
            if(data!=null)
                return Ok(data);
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Product entity)
        {
            await _uow.GetRepository<Product>().CreateAsync(entity);
            await _uow.SaveChangesAsync();
            return Created("", entity);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product entity)
        {
            var unchanged = await _uow.GetRepository<Product>().GetByIdAsync(entity.Id);
            if (unchanged != null)
            {
                _uow.GetRepository<Product>().Update(entity, unchanged);
                await _uow.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _uow.GetRepository<Product>().GetByIdAsync(id);
            if (deleted != null)
            {
                _uow.GetRepository<Product>().Delete(deleted);
                await _uow.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

    }
}
