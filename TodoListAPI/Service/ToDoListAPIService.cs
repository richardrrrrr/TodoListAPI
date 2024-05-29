using TodoListAPI.Dto;
using TodoListAPI.Interface;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Interface.IService;
using TodoListAPI.Model;
using TodoListAPI.Reporsitory;
namespace TodoListAPI.Service
{
	public class ToDoListAPIService : IToDoListAPIService
	{
		private readonly ToDoListAPIReporsitory _ToDoListAPIReporsitory;
		public ToDoListAPIService (ToDoListAPIReporsitory toDoListAPIReporsitory)
		{
			_ToDoListAPIReporsitory = toDoListAPIReporsitory;
		}
		public async Task<ToDoListDto> CreateToDoListAsync(CreateToDoList createToDoList)
		{
			return await _ToDoListAPIReporsitory.CreateToDoListAPIAsync(createToDoList);
		}

		

		public async Task<bool> DeleteToDoListAsync(int TodoId)
		{
			return await _ToDoListAPIReporsitory.DeleteToDoListAPIAsync(TodoId);
		}

		public  async Task<List<ToDoListDto>> GetAllToDoListsAsync(int userId)
		{
			return await _ToDoListAPIReporsitory.GetToDoListAPIAsync(userId);
		}

		public async Task<ToDoListDto> UpdateToDoListAsync(ToDoListDto toDoListDto)
		{
			return await _ToDoListAPIReporsitory.UpdateToDoListAPIAsync(toDoListDto);
		}
	}
}
