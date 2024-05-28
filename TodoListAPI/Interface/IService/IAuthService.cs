using TodoListAPI.Dto;
using TodoListAPI.Entity;

namespace TodoListAPI.Interface.IService
{
	public interface IAuthService
	{
		Task<string> GenerateTokenAsync(User user);
		Task<bool> ValidateTokenAsync(string token);
		Task<UserDto> ValidateCredentials(string username, string password);
	}
}
