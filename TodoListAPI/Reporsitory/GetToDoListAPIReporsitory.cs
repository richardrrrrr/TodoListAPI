using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface;

namespace TodoListAPI.Reporsitory
{
	public class GetToDoListAPIReporsitory :IReporsitory
	{
		private readonly ToDoListAPIDbcontext _ToDoListAPIDbcontext;
		private readonly IMapper _Mapper;

		public GetToDoListAPIReporsitory(ToDoListAPIDbcontext toDoListAPIDbcontext, IMapper mapper)
		{
			_ToDoListAPIDbcontext = toDoListAPIDbcontext;
			_Mapper = mapper;
		}

		public async Task<List<ToDoListDto>> GetToDoListAPIAsync(int id)
		{
			var ToDoLists = await _ToDoListAPIDbcontext.ToDoLists
													   .Where(item => item.UserId == id)
													   .ToListAsync();
			if (ToDoLists == null)
			{
				return null;
			}
			return _Mapper.Map<List<ToDoListDto>>(ToDoLists);  
		}
	}
}
