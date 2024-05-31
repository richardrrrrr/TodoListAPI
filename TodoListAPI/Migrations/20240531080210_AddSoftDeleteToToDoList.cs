using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteToToDoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ToDoLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(2023), new DateTime(2024, 6, 1, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(2017), false, new DateTime(2024, 5, 31, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(2026), new DateTime(2024, 5, 31, 19, 2, 10, 243, DateTimeKind.Local).AddTicks(2025), false, new DateTime(2024, 5, 31, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(1905), new DateTime(2024, 5, 31, 16, 2, 10, 243, DateTimeKind.Local).AddTicks(1914) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ToDoLists");

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7174), new DateTime(2024, 6, 1, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7169), new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "ToDoLists",
                keyColumn: "ToDoId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7177), new DateTime(2024, 5, 31, 18, 15, 39, 727, DateTimeKind.Local).AddTicks(7176), new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7055), new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7067) });
        }
    }
}
