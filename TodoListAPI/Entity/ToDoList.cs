using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListAPI.Entity
{
	public class ToDoList
	{
		public int ToDoId { get; set; }
		public int UserId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime? DueDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
	}
}
