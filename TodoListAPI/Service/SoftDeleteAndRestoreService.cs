using TodoListAPI.Dto;
using TodoListAPI.Entity;
using TodoListAPI.Interface;
using TodoListAPI.Interface.IReporsitory;
using TodoListAPI.Interface.IService;
namespace TodoListAPI.Service
{
	public class SoftDeleteAndRestoreService : ISoftDeleteAndRestoreService
	{
		private readonly ISoftDeleteAndRestoreRepository _SoftDeleteAndRestoreRepository;
		public SoftDeleteAndRestoreService(ISoftDeleteAndRestoreRepository softDeleteAndRestoreRepository)
		{
			_SoftDeleteAndRestoreRepository = softDeleteAndRestoreRepository;
		}

		public async Task<ToDoListDto> RestoreToDoListAsync(int ToDoId)
		{
			var ToDoList = await _SoftDeleteAndRestoreRepository.FindToDoListAsync(ToDoId);
			if (ToDoList != null && !ToDoList.IsDeleted)
			{
				ToDoList.IsDeleted = false;
				await _SoftDeleteAndRestoreRepository.UpdateAsync();
				return _SoftDeleteAndRestoreRepository.MapToDto(ToDoList);
			}
			return null;
		}

		public async Task<ToDoListDto> SoftDeleteToDoListAsync(int ToDoId)
		{
			var ToDoList = await _SoftDeleteAndRestoreRepository.FindToDoListAsync(ToDoId);
			if (ToDoList != null && !ToDoList.IsDeleted)
			{
				ToDoList.IsDeleted = true;
				await _SoftDeleteAndRestoreRepository.UpdateAsync();
				return _SoftDeleteAndRestoreRepository.MapToDto(ToDoList);
			}
			return null;
		}
	}
}
