using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MyLoginRequest = TodoListAPI.Model.LoginRequest;
using TodoListAPI.Interface.IService;
using TodoListAPI.Dto;


namespace TodoListAPI.Controllers
{
	
		[ApiController]
		[Route("api/[controller]")]
		public class AuthController : ControllerBase
		{
			private readonly IAuthService _AuthService;

			public AuthController(IAuthService authService)
			{
				_AuthService = authService;
			}

			[HttpPost("login")]
			public async Task<IActionResult> Login([FromBody] MyLoginRequest loginRequest)
			{
			

			var user = await _AuthService.ValidateCredentials(loginRequest);
				if (user == null)
				{
					return Unauthorized();
				}
			

			var token = await _AuthService.GenerateTokenAsync(user);
				return Ok(new { Token = token });
			}
		}
	
}
