using TodoListAPI.Dto;

namespace TodoListAPI.Interface.IReporsitory
{
	public interface IUserAPIReporsitory
	{
		Task<UserDto> GetUserByUsernameAndPassword(string UserName, string Password);
	}
}
