using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDoLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "UserName" },
                values: new object[] { 1, new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8091), "john.doe@example.com", "hashed_password", new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8101), "john_doe" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoId", "CreatedAt", "Description", "DueDate", "IsCompleted", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8221), "Complete the monthly report by the end of the day.", new DateTime(2024, 5, 23, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8215), false, "Complete the report", new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8222), 1 },
                    { 2, new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8228), "Discuss project updates and next steps.", new DateTime(2024, 5, 22, 19, 46, 55, 954, DateTimeKind.Local).AddTicks(8227), false, "Meeting with the team", new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8229), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_UserId",
                table: "ToDoLists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
