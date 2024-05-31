using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface;
using TodoListAPI.Interface.IReporsitory;
namespace TodoListAPI.Reporsitory
{
	public class SoftDeleteAndRestoreRepository : ISoftDeleteAndRestoreRepository
	{
		private readonly IMapper _Mapper;
		private readonly ToDoListAPIDbcontext _ToDoListAPIDbcontext;
		public SoftDeleteAndRestoreRepository(ToDoListAPIDbcontext toDoListAPIDbcontext, IMapper mapper)
		{
			_ToDoListAPIDbcontext = toDoListAPIDbcontext;
			_Mapper = mapper;
		}

		public async Task<ToDoList> FindToDoListAsync(int Id)
		{
			return await _ToDoListAPIDbcontext.ToDoLists
											  .Where(t => t.ToDoId == Id)
											  .FirstOrDefaultAsync();
		}

		public async Task UpdateAsync()
		{
			await _ToDoListAPIDbcontext.SaveChangesAsync();
		}

		public ToDoListDto MapToDto(ToDoList toDoList)
		{
			return _Mapper.Map<ToDoListDto>(toDoList);
		}
	}
}
