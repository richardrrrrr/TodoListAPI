using TodoListAPI.Entity;

namespace TodoListAPI.Interface.IService
{
	public interface IJWTService
	{
		Task<string> GenerateTokenAsync(User user);
		Task<bool> ValidateTokenAsync(string token);
	}
}
