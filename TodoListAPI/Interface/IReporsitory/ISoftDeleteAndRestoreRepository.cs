using TodoListAPI.Dto;
using TodoListAPI.Entity;

namespace TodoListAPI.Interface.IReporsitory
{
	public interface ISoftDeleteAndRestoreRepository
	{
		Task<ToDoList> FindToDoListAsync(int ToDoId);
		Task UpdateAsync();
		ToDoListDto MapToDto(ToDoList toDoList);
	}
}
