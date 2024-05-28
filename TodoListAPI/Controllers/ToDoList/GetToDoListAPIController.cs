using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Reporsitory;

namespace TodoListAPI.Controllers.ToDoList
{
    [ApiController]
    [Route("[controller]")]
    public class GetToDoListAPIController : ControllerBase
    {
        private readonly IGetToDoListAPIReporsitory _Reporsitory;
        public GetToDoListAPIController(IGetToDoListAPIReporsitory reporsitory)
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
