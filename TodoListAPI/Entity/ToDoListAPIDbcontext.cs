using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Entity
{
	public class ToDoListAPIDbcontext : DbContext
	{
		public DbSet<ToDoList> ToDoList { get; set; }
		public DbSet<User> User { get; set; }

		public ToDoListAPIDbcontext(DbContextOptions options) : base(options) 
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasMany(u => u.ToDoLists)
				.WithOne(u => u.User)
				.HasForeignKey(u => u.UserId);

			modelBuilder.Entity<ToDoList>().HasKey(t => t.ToDoId);

			//Seed Data
			modelBuilder.Entity<User>().HasData(
	   new User
	   {
		   UserId = 1,
		   UserName = "john_doe",
		   Email = "john.doe@example.com",
		   PasswordHash = "hashed_password", // 注意：實際應用中應使用安全的密碼散列策略
		   CreatedAt = DateTime.Now,
		   UpdatedAt = DateTime.Now
	   }
   );

			modelBuilder.Entity<ToDoList>().HasData(
				new ToDoList
				{
					ToDoId = 1,
					UserId = 1,
					Title = "Complete the report",
					Description = "Complete the monthly report by the end of the day.",
					IsCompleted = false,
					DueDate = DateTime.Now.AddDays(1),
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
				new ToDoList
				{
					ToDoId = 2,
					UserId = 1,
					Title = "Meeting with the team",
					Description = "Discuss project updates and next steps.",
					IsCompleted = false,
					DueDate = DateTime.Now.AddHours(3),
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				}
			);

		}

	}
}
