using APIAgroCoreLogin.Model;
using APIAgroCoreLogin.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Login([FromBody] BasicUserRequestModel request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Senha))
            {
                return BadRequest(new { Message = "Invalid user data" });
            }

            var user = await _userRepository.GetByEmailAndSenhaAsync(request.Email, request.Senha);
            if (user != null)
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

            var usuario = new Usuario
            {
                Email = request.Email,
                Senha = request.Senha
            };

            var created = await _userRepository.CreateAsync(usuario);

            return CreatedAtAction(nameof(CreateUser), new { id = created.Id }, new { Message = "User created successfully", UserId = created.Id });
        }
    }
}
