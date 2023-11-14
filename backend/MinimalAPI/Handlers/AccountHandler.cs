using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Identity;

namespace MinimalAPI.Handlers;

public static class AccountHandler
{
    public static async Task<IResult> SignUp(UserManager<User> userManager, SignUpDTO dto)
    {
        var user = dto.ConvertToEntity();
        var result = await userManager.CreateAsync(user, dto.Password);

        return result.Succeeded
            ? TypedResults.Created($"/api/account/{user.Id}", UserDTO.Create(user))
            : TypedResults.BadRequest(result.Errors.Select(x => x.Description));
    }

    public static async Task<IResult> SignIn(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration config, SignInDTO dto)
    {
        var result = await signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

        return await CreateJwtToken(userManager, config, dto.Email) is string token && result.Succeeded
            ? TypedResults.Ok(new { token })
            : TypedResults.BadRequest("Invalid email or password");
    }

    public static async Task<IResult> GetDetails(HttpRequest request, UserManager<User> userManager)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.GetUserId());

        return user is null
            ? TypedResults.NotFound($"Could not find user through supplied auth token")
            : TypedResults.Ok(UserDTO.Create(user));
    }

    private static async Task<string?> CreateJwtToken(UserManager<User> userManager, IConfiguration config, string email)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user is null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(config["JWT_KEY"]!);
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("user_id", user.Id)
            }),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = config["JwtSettings:Issuer"],
            Audience = config["JwtSettings:Audience"]
        });

        return tokenHandler.WriteToken(token);
    }
}