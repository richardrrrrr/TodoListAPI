using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Model;
using MyLoginRequest = TodoListAPI.Model.LoginRequest;

namespace TodoListAPI.Interface.IService
{
	public interface IAuthService
	{
		Task<string> GenerateTokenAsync(UserDto user);
		Task<bool> ValidateTokenAsync(string token);
		Task<UserDto> ValidateCredentials(MyLoginRequest loginRequest);
	}
}
