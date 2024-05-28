using TodoListAPI.Dto;
using TodoListAPI.Entity;

namespace TodoListAPI.Interface.IService
{
	public interface IUserAPIService
	{
		Task<UserDto> GetUserAPIAsync(int userId);
	}
}
