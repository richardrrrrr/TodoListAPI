using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriorityToToDoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDoLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "Priority", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7174), new DateTime(2024, 6, 1, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7169), 0, new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "Priority", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7177), new DateTime(2024, 5, 31, 18, 15, 39, 727, DateTimeKind.Local).AddTicks(7176), 0, new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7055), new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7067) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDoLists");

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8221), new DateTime(2024, 5, 23, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8215), new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8222) });

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8228), new DateTime(2024, 5, 22, 19, 46, 55, 954, DateTimeKind.Local).AddTicks(8227), new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8229) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8091), new DateTime(2024, 5, 22, 16, 46, 55, 954, DateTimeKind.Local).AddTicks(8101) });
        }
    }
}
