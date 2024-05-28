using TodoListAPI.Entity;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Reporsitory.ToDoList;
using TodoListAPI.Interface.IReporsitory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoListAPI.Interface.IService;
using TodoListAPI.Service;
using TodoListAPI.Reporsitory.Account;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped< IAuthService, AuthService>();
builder.Services.AddScoped<IUserAPIReporsitory, UserAPIReporsitory>();
builder.Services.AddControllers();
//連接字串
builder.Services.AddDbContext<ToDoListAPIDbcontext>
	(options =>
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	}); 

// 添加 JWT 驗證配置
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	var JwtConfig = builder.Configuration.GetSection("Jwt");
	var SecretKey = JwtConfig["Key"];

	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
		ValidateIssuer = false,
		ValidateAudience = false,
		ClockSkew = TimeSpan.Zero
	};
});

builder.Services.AddScoped<IGetToDoListAPIReporsitory, GetToDoListAPIReporsitory>();
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
