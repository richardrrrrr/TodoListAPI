using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Interface.IService;
using TodoListAPI.Reporsitory.Account;
namespace TodoListAPI.Service.Account
{
	public class UserAPIService : IUserAPIService
	{
		private readonly IUserAPIReporsitory _GetUserAPIReporsitory;

		public UserAPIService (IUserAPIReporsitory getUserAPIReporsitory)
		{
			_GetUserAPIReporsitory = getUserAPIReporsitory;
		}

		public async Task<UserDto> GetUserAPIAsync(int userId)
		{
			return await _GetUserAPIReporsitory.GetUserAPIAsync(userId); 
		}
	}
}
