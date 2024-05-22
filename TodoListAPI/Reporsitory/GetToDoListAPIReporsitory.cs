using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;

namespace TodoListAPI.Reporsitory
{
	public class GetToDoListAPIReporsitory
	{
		private readonly ToDoListAPIDbcontext _ToDoListAPIDbcontext;
		private readonly IMapper _Mapper;

		public GetToDoListAPIReporsitory(ToDoListAPIDbcontext toDoListAPIDbcontext, IMapper mapper)
		{
			_ToDoListAPIDbcontext = toDoListAPIDbcontext;
			_Mapper = mapper;
		}

		public List<ToDoListDto> GetAllToDoListAPI()
		{
			var ToDoLists = _ToDoListAPIDbcontext.ToDoList.ToList();  
			return _Mapper.Map<List<ToDoListDto>>(ToDoLists);  
		}
	}
}
