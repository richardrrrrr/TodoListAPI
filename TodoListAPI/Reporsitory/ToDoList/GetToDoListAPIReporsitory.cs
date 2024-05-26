using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface.IReporsitory;

namespace TodoListAPI.Reporsitory.ToDoList
{
    public class GetToDoListAPIReporsitory : IGetToDoListAPIReporsitory
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
            var GetToDoList = await _ToDoListAPIDbcontext.ToDoLists
                                                       .Where(item => item.UserId == id)
                                                       .ToListAsync();
            if (GetToDoList == null)
            {
                return null;
            }
            return _Mapper.Map<List<ToDoListDto>>(GetToDoList);
        }
    }
}
