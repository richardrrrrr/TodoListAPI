using TodoListAPI.Dto;
using TodoListAPI.Model;

namespace TodoListAPI.Interface.IService
{
	public interface IToDoListAPIService
	{
		Task<List<ToDoListDto>> GetAllToDoListsAsync(int userId);
		Task<ToDoListDto> CreateToDoListAsync(CreateToDoList createToDoList);
		Task<ToDoListDto> UpdateToDoListAsync(ToDoListDto toDoListDto);
		Task<bool> DeleteToDoListAsync(int id);
	}
}
