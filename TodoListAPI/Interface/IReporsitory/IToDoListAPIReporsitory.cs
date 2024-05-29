using TodoListAPI.Dto;
using TodoListAPI.Model;

namespace TodoListAPI.Interface.IReporsitory
{
    public interface IToDoListAPIReporsitory
    {

        Task<List<ToDoListDto>> GetToDoListAPIAsync(int id);
		Task<ToDoListDto> CreateToDoListAPIAsync(CreateToDoList createToDoList);
		Task<ToDoListDto> UpdateToDoListAPIAsync(UpdateToDoList UpdateToDoList);
		Task<bool> DeleteToDoListAPIAsync(int id);

	}
}
