using TodoListAPI.Dto;
using TodoListAPI.Model;

namespace TodoListAPI.Interface.IService
{
	public interface IToDoListAPIService
	{
		Task<List<ToDoListDto>> GetAllToDoListsAsync(int UserId, int PageNumber, int PageSize);
		Task<ToDoListDto> CreateToDoListAsync(CreateToDoList createToDoList);
		Task<ToDoListDto> UpdateToDoListAsync(UpdateToDoList UpdateToDoList);
		Task<bool> DeleteToDoListAsync(int id);
	}
}
