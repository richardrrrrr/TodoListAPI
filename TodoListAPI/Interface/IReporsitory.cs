using TodoListAPI.Dto;

namespace TodoListAPI.Interface
{
	public interface IReporsitory
	{	
		
			Task<List<ToDoListDto>> GetToDoListAPIAsync(int id);

	}
}
