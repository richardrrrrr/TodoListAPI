using TodoListAPI.Dto;

namespace TodoListAPI.Interface.IReporsitory
{
	public interface IUserAPIReporsitory
	{
		Task<UserDto> GetUsernameAndPassword(string UserName, string Password);
	}
}
