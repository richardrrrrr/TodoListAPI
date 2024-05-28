namespace TodoListAPI.Dto
{
	public class ToDoListDto
	{
		public int ToDoId { get; set; }
		public int UserId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime? DueDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
