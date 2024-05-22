using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Entity
{
	public class User
	{
		
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		// Navigation property
		public List<ToDoList> ToDoLists { get; set; }
	}
}
