﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface.IReporsitory;

namespace TodoListAPI.Reporsitory.Account
{
    public class UserAPIReporsitory : IUserAPIReporsitory
	{
		
		private readonly ToDoListAPIDbcontext _ToDoListAPIDbcontext;
		private readonly IMapper _Mapper;
		public UserAPIReporsitory(ToDoListAPIDbcontext toDoListAPIDbcontext, IMapper mapper)
		{
			_ToDoListAPIDbcontext = toDoListAPIDbcontext;
			_Mapper = mapper;
		}

		public async Task<UserDto> GetUserByUsernameAndPassword(string UserName, string Password)
		{
			var GetUser = await _ToDoListAPIDbcontext.Users
													 .FirstOrDefaultAsync(item => item.UserName == UserName && item.PasswordHash == Password);
			if (GetUser == null)
			{
				return null;
			}
			return _Mapper.Map<UserDto>(GetUser);
		}
	}
}