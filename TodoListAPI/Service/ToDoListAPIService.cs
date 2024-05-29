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
		private readonly IToDoListAPIReporsitory _ToDoListAPIReporsitory;
		public ToDoListAPIService (IToDoListAPIReporsitory toDoListAPIReporsitory)
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

		public  async Task<List<ToDoListDto>> GetAllToDoListsAsync(int userId, int PageNumber, int PageSize)
		{
			var ToDoLists =  await _ToDoListAPIReporsitory.GetToDoListAPIAsync(userId);
			return ToDoLists.OrderBy(item =>item.CreatedAt)
							.Skip((PageNumber-1) * PageSize)
							.Take(PageSize)
							.ToList();
		}

		public async Task<ToDoListDto> UpdateToDoListAsync(UpdateToDoList UpdateToDoList)
		{
			return await _ToDoListAPIReporsitory.UpdateToDoListAPIAsync(UpdateToDoList);
		}
	}
}
