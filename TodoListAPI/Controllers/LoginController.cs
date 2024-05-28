using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dto;
using TodoListAPI.Interface.IService;

namespace TodoListAPI.Controllers
{
	public class LoginController
	{
		[ApiController]
		[Route("api/auth")]
		public class AuthController : ControllerBase
		{
			private readonly IAuthService _AuthService;

			public AuthController(IAuthService authService)
			{
				_AuthService = authService;
			}

			[HttpPost("login")]
			public async Task<IActionResult> Login([FromBody] UserDto userDto)
			{
				var user = await _AuthService.ValidateCredentials(userDto.UserName, userDto.PasswordHash);
				if (user == null)
				{
					return Unauthorized();
				}

				var token = _AuthService.GenerateTokenAsync(user);
				return Ok(new { Token = token });
			}
		}
	}
}
