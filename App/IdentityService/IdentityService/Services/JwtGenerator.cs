using IdentityService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Services;

internal class JwtGenerator : IJwtGenerator<AppUser>
{
    private readonly IConfiguration _configuration;
    public JwtGenerator(IConfiguration configuration) => _configuration = configuration 
        ?? throw new ArgumentNullException();

    public string GenerateJwtToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Secret"]
            ?? throw new Exception("Secret key was not found"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id",user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Presenter")
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}