using TodoListAPI.Dto;
using TodoListAPI.Model;

namespace TodoListAPI.Interface.IReporsitory
{
	public interface IUserAPIReporsitory
	{
		Task<UserDto> GetUsernameAndPassword(string UserName, string Password);
	}
}
