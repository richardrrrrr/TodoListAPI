using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface.IReporsitory;

namespace TodoListAPI.Reporsitory.Account
{
    public class GetUserAPIReporsitory : IGetUserAPIReporsitory
	{
		
		private readonly ToDoListAPIDbcontext _ToDoListAPIDbcontext;
		private readonly IMapper _Mapper;
		public GetUserAPIReporsitory(ToDoListAPIDbcontext toDoListAPIDbcontext, IMapper mapper)
		{
			_ToDoListAPIDbcontext = toDoListAPIDbcontext;
			_Mapper = mapper;
		}

		public async Task<List<UserDto>> GetUserAPIAsync(int id)
		{
			var GetUser = await _ToDoListAPIDbcontext.Users
													 .Where(item => item.UserId == id)
													 .ToListAsync();
			if (GetUser == null)
			{
				return null;
			}
			return _Mapper.Map<List<UserDto>>(GetUser);
		}
	}
}
