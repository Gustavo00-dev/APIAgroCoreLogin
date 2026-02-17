using APIAgroCoreLogin.Model;
using APIAgroCoreLogin.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace APIAgroCoreLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Rota: POST /api/login/login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] BasicUserRequestModel request)
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] BasicUserRequestModel request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Senha))
            {
                return BadRequest(new { Message = "Invalid user data" });
            }

            await _userRepository.CreateAsync(request);

            return Created(string.Empty, new { Message = "User created successfully" });
        }
    }
}
