using System.IdentityModel.Tokens.Jwt;

namespace MinimalAPI.Extensions;

public static class HttpRequestExtensions
{
    public static string? GetUserId(this HttpRequest request)
    {
        var tokenString = request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokenString);
        return token.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
    }
}