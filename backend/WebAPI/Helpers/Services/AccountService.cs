using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Interface.Services;
using WebAPI.Models;
using WebAPI.Models.Identity;

namespace WebAPI.Helpers.Services;

public class AccountService : IAccountService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;

    public AccountService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> CreateJwtToken(string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("unique_id", user!.Id)
            }),
            Expires = DateTime.UtcNow.AddMonths(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = "https://manero.com",
            Audience = "https://manero.com"
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }

    public string? GetIdFromToken(string? tokenString)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokenString);
        var id = token.Claims.FirstOrDefault(x => x.Type == "unique_id")?.Value;
        
        return id;
    }

    public async Task<ServiceStatusCodeReturn> IsValidUserId(string? userId)
    {
        var status = new ServiceStatusCodeReturn
        {
            StatusCode = 200
        };

        if (userId == null)
        {
            status.StatusCode = 403;
            status.StatusMessage = "Jwt token did not contain user id.";
        }

        // It is not possible to enter this if statement unless the account has been deleted and therefore the token is invalid.
        if (await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId) == null)
        {
            status.StatusCode = 401;
            status.StatusMessage = "The token you tried to use is no longer valid.";
        }

        return status;
    }
}
