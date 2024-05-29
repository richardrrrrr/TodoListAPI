using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dto;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Model;
using TodoListAPI.Reporsitory;

namespace TodoListAPI.Controllers.ToDoList
{
    [ApiController]
    [Route("[controller]")]
    
    public class ToDoListAPIController : ControllerBase
    {
        private readonly IToDoListAPIReporsitory _ToDoListAPIService;
        public ToDoListAPIController(IToDoListAPIReporsitory reporsitory)
        {
            _ToDoListAPIService = reporsitory;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetToDoListAPI(int UserId)
        {
            var GetById = await _ToDoListAPIService.GetToDoListAPIAsync(UserId);
            if (GetById == null)
            {
                return NotFound();
            }
            return Ok(GetById);
        }

		[HttpPost]
		public async Task<IActionResult> CreateToDoListAPI([FromBody] CreateToDoList createToDoList)
		{
			var createdToDoList = await _ToDoListAPIService.CreateToDoListAPIAsync(createToDoList);
			if (createdToDoList == null)
			{
				return BadRequest("Unable to create the to-do list.");
			}
			return CreatedAtAction(nameof(GetToDoListAPI), new { UserId = createdToDoList.UserId }, createdToDoList);
		}

		[HttpPut("{ToDoId}")]
		public async Task<IActionResult> UpdateToDoListAPI(int ToDoId, [FromBody] ToDoListDto toDoListDto)
		{
			if (ToDoId != toDoListDto.ToDoId)
			{
				return BadRequest("ID mismatch in the request.");
			}

			var updatedToDoList = await _ToDoListAPIService.UpdateToDoListAPIAsync(toDoListDto);
			if (updatedToDoList == null)
			{
				return NotFound();
			}
			return Ok(updatedToDoList);
		}

		[HttpDelete("{ToDoId}")]
		public async Task<IActionResult> DeleteToDoListAPI(int ToDoId)
		{
			var result = await _ToDoListAPIService.DeleteToDoListAPIAsync(ToDoId);
			if (!result)
			{
				return NotFound();
			}
			return NoContent();  // Successfully deleted the to-do list
		}
	}
}
