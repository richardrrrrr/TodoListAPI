using AutoMapper;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
namespace TodoListAPI.Interface.AutoMapper
{
    public class ToDoListAPIAutoMapper : Profile
    {
        public ToDoListAPIAutoMapper()
        {
            CreateMap<ToDoList, ToDoListDto>();
            CreateMap<User, UserDto>();
        }
    }
}
