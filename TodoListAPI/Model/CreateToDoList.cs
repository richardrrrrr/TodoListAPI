namespace TodoListAPI.Model
{
	public class CreateToDoList
	{
		
		public int UserId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime? DueDate { get; set; }
	}
}
