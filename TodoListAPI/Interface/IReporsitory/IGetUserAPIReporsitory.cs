using TodoListAPI.Dto;

namespace TodoListAPI.Interface.IReporsitory
{
	public interface IGetUserAPIReporsitory
	{
		Task<List<UserDto>> GetUserAPIAsync(int id);
	}
}
