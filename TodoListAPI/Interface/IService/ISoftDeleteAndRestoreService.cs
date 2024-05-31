using TodoListAPI.Dto;

namespace TodoListAPI.Interface.IService
{
	public interface ISoftDeleteAndRestoreService
	{
		Task<ToDoListDto> SoftDeleteToDoListAsync(int ToDoId);
		Task<ToDoListDto> RestoreToDoListAsync(int ToDoId);
	}
}
