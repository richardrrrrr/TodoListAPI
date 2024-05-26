using TodoListAPI.Dto;

namespace TodoListAPI.Interface.IReporsitory
{
    public interface IGetToDoListAPIReporsitory
    {

        Task<List<ToDoListDto>> GetToDoListAPIAsync(int id);
       

    }
}
