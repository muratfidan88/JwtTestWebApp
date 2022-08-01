using JwtTestWebApp.JwtApi.Data.Entities;
using JwtTestWebApp.JwtApi.Repositories;
using JwtTestWebApp.JwtApi.Tools.Jwt;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JwtTestWebApp.JwtApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUow _uow;

        public AuthController(IUow uow)
        {
            _uow = uow;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(AppUser model)
        {
            var checkUser = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.UserName == model.UserName);
            if(checkUser == null)
            {
                model.RoleId = 2;
                await _uow.GetRepository<AppUser>().CreateAsync(model);
                await _uow.SaveChangesAsync();
                return Created("", model);
            }
            return BadRequest("Aynı kullanıcı adı ile daha önceden kayıt olunmuş");
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUser model)
        {
            var checkUser = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.UserName == model.UserName && x.Password == model.Password);
            if(checkUser != null)
            {
                var token = JwtTokenGenerator.GenerateToken(checkUser);
                return Ok(token);
            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }

    }
}
