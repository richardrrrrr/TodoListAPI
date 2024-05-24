using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Interface;
using TodoListAPI.Reporsitory;

namespace TodoListAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GetToDoListAPIController : ControllerBase
	{
		private readonly IReporsitory _Reporsitory;
		public GetToDoListAPIController(IReporsitory reporsitory)
		{
			_Reporsitory = reporsitory;
		}
		[HttpGet("{UserId}")]
		public async Task<IActionResult> GetToDoListAPIById(int UserId)
		{
			var GetById = await _Reporsitory.GetToDoListAPIAsync(UserId);
			if (GetById == null) 
			{
				return NotFound();
			}
			return Ok(GetById);
		}
	}
}
