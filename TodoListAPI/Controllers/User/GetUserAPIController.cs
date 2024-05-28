using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dto;
using TodoListAPI.Interface.IService;
using TodoListAPI.Service.Account;

namespace TodoListAPI.Controllers.Controller
{

	public class GetUserAPIController :ControllerBase
	{
		private readonly IUserAPIService _UserAPIService;
		
		public GetUserAPIController (IUserAPIService userAPIService, IAuthService jWTService)
		{
			_UserAPIService = userAPIService;
			
		}
		// GET: api/users/{id}
		[HttpGet("{UserId}")]
		[Authorize]
		public async Task<IActionResult> GetUserById(int UserId)
		{
			var UserDto = await _UserAPIService.GetUserAPIAsync(UserId);
			if (UserDto == null)
			{
				return NotFound();
			}
			return Ok(UserDto);
		}
	}
}
