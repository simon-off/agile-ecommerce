namespace WebAPI.Helpers.Extensions;

public static class HttpRequestExtensions
{
    public static string? GetAuthString(this HttpRequest request)
    {
        return request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    }
}