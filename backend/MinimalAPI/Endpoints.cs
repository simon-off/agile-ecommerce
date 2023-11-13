using MinimalAPI.Validation;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Handlers;

namespace MinimalAPI;

public static class Endpoints
{
    public static void Map(WebApplication app)
    {
        var api = app.MapGroup("/api");
        api.MapGet("/products", ProductsHandler.GetAll);
        api.MapGet("/products/{id}", ProductsHandler.GetById);
        api.MapGet("/products/count", ProductsHandler.Count);
        api.MapGet("/categories", CategoriesHandler.GetAll);
        api.MapGet("/tags", TagsHandler.GetAll);
        api.MapGet("/orders", OrdersHandler.GetAll).RequireAuthorization();
        api.MapPost("/orders", OrdersHandler.Create).AddEndpointFilter<ValidationFilter<OrderCreateDTO>>();
        api.MapPost("/account/signup", AccountHandler.SignUp).AddEndpointFilter<ValidationFilter<SignUpDTO>>();
        api.MapPost("/account/signin", AccountHandler.SignIn).AddEndpointFilter<ValidationFilter<SignInDTO>>();
    }
}
