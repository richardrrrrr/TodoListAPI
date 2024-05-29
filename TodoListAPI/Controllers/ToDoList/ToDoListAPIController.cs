using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dto;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Interface.IService;
using TodoListAPI.Model;
using TodoListAPI.Reporsitory;
using TodoListAPI.Service;

namespace TodoListAPI.Controllers.ToDoList
{
    [ApiController]
    [Route("[controller]")]
    
    public class ToDoListAPIController : ControllerBase
    {
        private readonly IToDoListAPIService _ToDoListAPIService;
        public ToDoListAPIController(IToDoListAPIService toDoListAPIService)
        {
            _ToDoListAPIService = toDoListAPIService;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetToDoListAPI(int UserId, int PageNumber = 1, int PageSize = 10)
        {
            var GetById = await _ToDoListAPIService.GetAllToDoListsAsync(UserId, PageNumber, PageSize);
            if (GetById == null || !GetById.Any())
            {
                return NotFound();
            }
            return Ok(GetById);
        }

		[HttpPost]
		public async Task<IActionResult> CreateToDoListAPI([FromBody] CreateToDoList createToDoList)
		{
			var createdToDoList = await _ToDoListAPIService.CreateToDoListAsync(createToDoList);
			if (createdToDoList == null)
			{
				return BadRequest("Unable to create the to-do list.");
			}
			return CreatedAtAction(nameof(GetToDoListAPI), new { UserId = createdToDoList.UserId }, createdToDoList);
		}

		[HttpPut("{ToDoId}")]
		public async Task<IActionResult> UpdateToDoListAPI(int ToDoId, [FromBody] UpdateToDoList UpdateToDoList)
		{
			if (ToDoId != UpdateToDoList.ToDoId)
			{
				return BadRequest("ID mismatch in the request.");
			}

			var updatedToDoList = await _ToDoListAPIService.UpdateToDoListAsync(UpdateToDoList);
			if (updatedToDoList == null)
			{
				return NotFound();
			}
			return Ok(updatedToDoList);
		}

		[HttpDelete("{ToDoId}")]
		public async Task<IActionResult> DeleteToDoListAPI(int ToDoId)
		{
			var result = await _ToDoListAPIService.DeleteToDoListAsync(ToDoId);
			if (!result)
			{
				return NotFound();
			}
			return NoContent();  // Successfully deleted the to-do list
		}
	}
}
