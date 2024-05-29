using AutoMapper;
using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Model;
namespace TodoListAPI.Interface.AutoMapper
{
    public class ToDoListAPIAutoMapper : Profile
    {
        public ToDoListAPIAutoMapper()
        {

            CreateMap<ToDoList, ToDoListDto>();
            CreateMap<User, UserDto>();
            CreateMap<ToDoListDto, ToDoList>();
            CreateMap<CreateToDoList, ToDoList>();
		}
    }
}
