using Application.Contracts.Users;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest request)
        {
            string error = await _userService.Register(request);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserRequest request)
        {
            var (token, error) = await _userService.Login(request);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            Response.Cookies.Append("super-deper-cookie", token);

            return Ok(token);
        }
    }
}
