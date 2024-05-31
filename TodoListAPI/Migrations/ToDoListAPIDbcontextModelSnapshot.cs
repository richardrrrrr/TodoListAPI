﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoListAPI.Entity;

#nullable disable

namespace TodoListAPI.Migrations
{
    [DbContext(typeof(ToDoListAPIDbcontext))]
    partial class ToDoListAPIDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoListAPI.Entity.ToDoList", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToDoId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ToDoId");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoLists");

                    b.HasData(
                        new
                        {
                            ToDoId = 1,
                            CreatedAt = new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7174),
                            Description = "Complete the monthly report by the end of the day.",
                            DueDate = new DateTime(2024, 6, 1, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7169),
                            IsCompleted = false,
                            Priority = 0,
                            Title = "Complete the report",
                            UpdatedAt = new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7174),
                            UserId = 1
                        },
                        new
                        {
                            ToDoId = 2,
                            CreatedAt = new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7177),
                            Description = "Discuss project updates and next steps.",
                            DueDate = new DateTime(2024, 5, 31, 18, 15, 39, 727, DateTimeKind.Local).AddTicks(7176),
                            IsCompleted = false,
                            Priority = 0,
                            Title = "Meeting with the team",
                            UpdatedAt = new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7177),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TodoListAPI.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedAt = new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7055),
                            Email = "john.doe@example.com",
                            PasswordHash = "hashed_password",
                            UpdatedAt = new DateTime(2024, 5, 31, 15, 15, 39, 727, DateTimeKind.Local).AddTicks(7067),
                            UserName = "john_doe"
                        });
                });

            modelBuilder.Entity("TodoListAPI.Entity.ToDoList", b =>
                {
                    b.HasOne("TodoListAPI.Entity.User", "User")
                        .WithMany("ToDoLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoListAPI.Entity.User", b =>
                {
                    b.Navigation("ToDoLists");
                });
#pragma warning restore 612, 618
        }
    }
}
