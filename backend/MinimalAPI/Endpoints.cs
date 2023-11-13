using MinimalAPI.Validation;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Handlers;

namespace MinimalAPI;

public static class Endpoints
{
    public static void Map(WebApplication app)
    {
        var api = app.MapGroup("/api");
        // Product related
        api.MapGet("/products", ProductsHandler.GetAll);
        api.MapGet("/products/{id}", ProductsHandler.GetById);
        api.MapGet("/products/count", ProductsHandler.Count);
        api.MapGet("/categories", CategoriesHandler.GetAll);
        api.MapGet("/tags", TagsHandler.GetAll);
        // Order related
        api.MapGet("/orders", OrdersHandler.GetAll).RequireAuthorization();
        api.MapPost("/orders", OrdersHandler.Create).AddEndpointFilter<ValidationFilter<OrderCreateDTO>>();
        // Account related
        api.MapPost("/account", AccountHandler.GetDetails).RequireAuthorization();
        api.MapPost("/account/signup", AccountHandler.SignUp).AddEndpointFilter<ValidationFilter<SignUpDTO>>();
        api.MapPost("/account/signin", AccountHandler.SignIn).AddEndpointFilter<ValidationFilter<SignInDTO>>();
    }
}
