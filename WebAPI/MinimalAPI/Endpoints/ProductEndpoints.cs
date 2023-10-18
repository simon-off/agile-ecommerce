namespace MinimalAPI.Endpoints;

public static class ProductEndpoints
{
    public static void Map(WebApplication app)
    {
        var productsGroup = app.MapGroup("/products");

        productsGroup.MapGet("/", async context =>
        {
            // Get all todo items
            // await context.Response.WriteAsJsonAsync(new { Message = "All todo items" });
        });

        productsGroup.MapGet("/{id}", async context =>
        {
            // Get one todo item
            // await context.Response.WriteAsJsonAsync(new { Message = "One todo item" });
        });
    }
}