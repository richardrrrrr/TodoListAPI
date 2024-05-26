using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoListAPI.Entity;
using TodoListAPI.Interface.IService;
using System.Threading.Tasks;


namespace TodoListAPI.Service
{
	public class JWTService : IJWTService
	{
		private readonly IConfiguration _Configuration;

		public JWTService(IConfiguration configuration) 
		{
			_Configuration = configuration;
		}
		public async Task<string> GenerateTokenAsync(User user)
		{
			var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
			var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
				new Claim(ClaimTypes.Name, user.UserName),
			};

			var token = new JwtSecurityToken(
				issuer: _Configuration["Jwt:Issuer"],
				audience: _Configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: Credentials
			);
			return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
		}

		public async Task<bool> ValidateTokenAsync(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = _Configuration["Jwt:Issuer"],
				ValidAudience = _Configuration["Jwt:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here"))
			};

			try
			{
				SecurityToken validatedToken;
				tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
				return await Task.FromResult(true);
			}
			catch
			{
				return await Task.FromResult(false);
			}
		}

	}
}
