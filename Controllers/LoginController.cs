using APIAgroCoreLogin.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIAgroCoreLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Rota: POST /api/login/login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            if (request.Email == "admin" && request.Senha == "password")
            {
                return Ok(new { Message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
        }
    }
}
