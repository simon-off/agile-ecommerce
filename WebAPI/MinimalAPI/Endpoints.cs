using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Helpers.Extensions;
using MinimalAPI.Helpers.Validators;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI;

public static class Endpoints
{
    public static void Map(WebApplication app)
    {
        var api = app.MapGroup("/api");
        api.MapGet("/products", ProductsHandler.GetAll);
        api.MapGet("/products/{id}", ProductsHandler.GetById);
        api.MapGet("/categories", CategoriesHandler.GetAll);
        api.MapGet("/tags", TagsHandler.GetAll);
        api.MapGet("/orders", OrdersHandler.GetAll);
        api.MapPost("/orders", OrdersHandler.Create).AddEndpointFilter<ValidationFilter<NewOrderDto>>();
    }
}

static class ProductsHandler
{
    public static async Task<IResult> GetById(DataContext db, int id) =>
        await db.Products.OneAsDto(id)
        is ProductDto product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound($"Could not find product with id {id}");

    public static async Task<IResult> GetAll(DataContext db, string? category, string? tag) =>
        TypedResults.Ok(await db.Products.AllAsDtos(category, tag));
}

static class CategoriesHandler
{
    public static async Task<IResult> GetAll(DataContext db) =>
        TypedResults.Ok(await db.Categories.Select(x => x.Name).ToArrayAsync());
}

static class TagsHandler
{
    public static async Task<IResult> GetAll(DataContext db) =>
        TypedResults.Ok(await db.Tags.Select(x => x.Name).ToArrayAsync());
}

static class OrdersHandler
{
    public static async Task<IResult> GetAll(DataContext db) =>
        TypedResults.Ok(await db.Orders.AllAsDtos());

    public static async Task<IResult> Create(DataContext db, NewOrderDto newOrderDto)
    {
        decimal totalPrice = 0m;

        foreach (var item in newOrderDto.Items)
        {
            var productEntity = await db.Products
                .Include(x => x.AvailableSizes)
                .FirstOrDefaultAsync(x => x.Id == item.ProductId && x.AvailableSizes.Any(s => s.Id == item.SizeId));

            if (productEntity is null)
            {
                return TypedResults.NotFound($"Product with id: {item.ProductId} and size id: {item.SizeId} could not be found in the database");
            }
            totalPrice = productEntity.Price * item.Quantity;
        }

        var newAddressEntity = newOrderDto.Address.CreateEntity();
        await db.Addresses.AddAsync(newAddressEntity);

        var newCustomerEntity = newOrderDto.Customer.CreateEntity();
        await db.Customers.AddAsync(newCustomerEntity);
        await db.SaveChangesAsync();

        var newOrderEntity = newOrderDto.CreateEntity(totalPrice, newCustomerEntity.Id, newAddressEntity.Id);
        await db.Orders.AddAsync(newOrderEntity);
        await db.SaveChangesAsync();

        foreach (var item in newOrderDto.Items)
        {
            await db.OrderItems.AddAsync(item.CreateEntity(newOrderEntity.Id));
        }
        await db.SaveChangesAsync();

        return TypedResults.Created($"/api/orders/{newOrderEntity.Id}", OrderDto.Create(newOrderEntity));
    }
}
