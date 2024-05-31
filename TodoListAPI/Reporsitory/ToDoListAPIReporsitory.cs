using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Model;

namespace TodoListAPI.Reporsitory
{
    public class ToDoListAPIReporsitory : IToDoListAPIReporsitory
    {
        private readonly ToDoListAPIDbcontext _ToDoListAPIDbcontext;
        private readonly IMapper _Mapper;

        public ToDoListAPIReporsitory(ToDoListAPIDbcontext toDoListAPIDbcontext, IMapper mapper)
        {
            _ToDoListAPIDbcontext = toDoListAPIDbcontext;
            _Mapper = mapper;
        }

		public async Task<ToDoListDto> CreateToDoListAPIAsync(CreateToDoList createToDoList)
		{
            var Todolist = _Mapper.Map<ToDoList>(createToDoList);
            _ToDoListAPIDbcontext.ToDoLists.Add(Todolist);
            await _ToDoListAPIDbcontext.SaveChangesAsync();
            return _Mapper.Map<ToDoListDto>(Todolist);
		}

		public async Task<bool> DeleteToDoListAPIAsync(int id)
		{
			var ToDoList = await _ToDoListAPIDbcontext.ToDoLists
												  .FirstOrDefaultAsync(t => t.ToDoId == id);
			if (ToDoList == null)
			{
				return false;
			}

			_ToDoListAPIDbcontext.ToDoLists.Remove(ToDoList);
			await _ToDoListAPIDbcontext.SaveChangesAsync();
			return true;
		}

		public async Task<List<ToDoListDto>> GetToDoListAPIAsync(int id)
        {
            var GetToDoList = await _ToDoListAPIDbcontext.ToDoLists
                                                       .Where(item => item.UserId == id && !item.IsDeleted)
                                                       .ToListAsync();
            if (GetToDoList == null)
            {
                return null;
            }
            return _Mapper.Map<List<ToDoListDto>>(GetToDoList);
        }

		public async Task<ToDoListDto> UpdateToDoListAPIAsync(UpdateToDoList UpdateToDoList)
		{
			var ToDoList = await _ToDoListAPIDbcontext.ToDoLists
													   .FirstOrDefaultAsync(t => t.ToDoId == UpdateToDoList.ToDoId);
			if (ToDoList == null)
			{
				return null;
			}

			_Mapper.Map(UpdateToDoList, ToDoList);
			_ToDoListAPIDbcontext.ToDoLists.Update(ToDoList);
			await _ToDoListAPIDbcontext.SaveChangesAsync();
			return _Mapper.Map<ToDoListDto>(ToDoList);
		}

		
	}
}
