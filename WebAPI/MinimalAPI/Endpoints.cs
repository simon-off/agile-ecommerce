using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Entities;

namespace MinimalAPI;

public static class Endpoints
{
    public static void Map(WebApplication app)
    {
        var api = app.MapGroup("/api");
        api.MapGet("/products/", ProductsHandler.GetAll);
        api.MapGet("/products/{id}", ProductsHandler.GetById);
        api.MapGet("/categories", CategoriesHandler.GetAll);
        api.MapGet("/tags", TagsHandler.GetAll);
        api.MapGet("/orders", OrdersHandler.GetAll);
        api.MapPost("/orders", OrdersHandler.Create);
    }
}

static class ProductsHandler
{
    public static async Task<Results<Ok<ProductDto>, NotFound<string>>> GetById(DataContext db, int id) =>
        await db.Products.OneAsDto(id)
        is ProductDto product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound($"Could not find product with id {id}");

    public static async Task<Results<Ok<ProductDto[]>, NotFound<string>>> GetAll(DataContext db, [FromQuery] string? category, [FromQuery] string? tag) =>
        await db.Products.AllAsDtos(category, tag)
        is ProductDto[] products && products.Length > 0
        ? TypedResults.Ok(products)
        : TypedResults.NotFound(
            $"Could not find any products{(category != null || tag != null ? " with that category and/or tag" : "")}");
}

static class CategoriesHandler
{
    public static async Task<Results<Ok<string[]>, NotFound<string>>> GetAll(DataContext db) =>
        await db.Categories.Select(x => x.Name).ToArrayAsync()
        is string[] categories
        ? TypedResults.Ok(categories)
        : TypedResults.NotFound("Could not find any categories");
}

static class TagsHandler
{
    public static async Task<Results<Ok<string[]>, NotFound<string>>> GetAll(DataContext db) =>
        await db.Tags.Select(x => x.Name).ToArrayAsync()
        is string[] tags
        ? TypedResults.Ok(tags)
        : TypedResults.NotFound("Could not find any tags");
}

static class OrdersHandler
{
    public static async Task<Results<Ok<OrderDto[]>, NotFound<string>>> GetAll(DataContext db) =>
        await db.Orders.AllAsDtos()
            is OrderDto[] orders && orders.Length > 0
            ? TypedResults.Ok(orders)
            : TypedResults.NotFound("Could not find any orders");

    public static async Task<Results<Created<OrderDto>, ValidationProblem, NotFound<string>>> Create(DataContext db, NewOrderDto newOrderDto)
    {
        decimal totalPrice = 0;

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

static class DbSetExtensions
{
    public static async Task<ProductDto?> OneAsDto(this DbSet<ProductEntity> products, int id) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id)
            is ProductEntity entity
            ? ProductDto.Create(entity)
            : null;

    public static async Task<ProductDto[]> AllAsDtos(this DbSet<ProductEntity> products, string? category, string? tag) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Where(x => category == null || x.Category == null || x.Category.Name.ToLower() == category.ToLower())
            .Where(x => tag == null || x.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
            .Select(x => ProductDto.Create(x))
            .ToArrayAsync();

    public static async Task<OrderDto[]> AllAsDtos(this DbSet<OrderEntity> orders) =>
        await orders
            .Include(x => x.Customer)
            .Include(x => x.Address)
            .Include(x => x.Status)
            .Include(x => x.Items)
            .Select(x => OrderDto.Create(x))
            .ToArrayAsync();
}
