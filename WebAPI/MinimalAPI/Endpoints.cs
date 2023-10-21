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

    public static async Task<Results<Created, ValidationProblem, NotFound<string>>> Create(DataContext db, NewOrderDto newOrderDto)
    {
        decimal totalPrice = 0;

        foreach (var item in newOrderDto.Items)
        {
            var productEntity = await db.Products
                .Include(x => x.AvailableSizes)
                .FirstOrDefaultAsync(x => x.Id == item.ProductId && x.AvailableSizes.Any(s => s.Id == item.SizeId));

            if (productEntity is null)
            {
                return TypedResults.NotFound("One of the products in the chosen size could not be found in the database");
            }

            totalPrice = productEntity.Price * item.Quantity;
        }

        var newAddressEntity = new AddressEntity
        {
            StreetAddress = newOrderDto.Address.StreetAddress,
            City = newOrderDto.Address.City,
            PostalCode = newOrderDto.Address.PostalCode
        };
        await db.Addresses.AddAsync(newAddressEntity);

        var newCustomerEntity = new CustomerEntity
        {
            FirstName = newOrderDto.Customer.FirstName,
            LastName = newOrderDto.Customer.LastName,
            Email = newOrderDto.Customer.Email,
            PhoneNumber = newOrderDto.Customer.PhoneNumber,
        };
        await db.Customers.AddAsync(newCustomerEntity);

        var newOrderEntity = new OrderEntity
        {
            TotalPrice = totalPrice,
            CustomerId = newCustomerEntity.Id,
            AddressId = newAddressEntity.Id,
        };
        await db.Orders.AddAsync(newOrderEntity);

        foreach (var item in newOrderDto.Items)
        {
            var newOrderItemEntity = new OrderItemEntity
            {
                OrderId = newOrderEntity.Id,
                ProductId = item.ProductId,
                SizeId = item.SizeId,
                Quantity = item.Quantity
            };
            await db.OrderItems.AddAsync(newOrderItemEntity);
            newOrderEntity.Items.Add(newOrderItemEntity);
        }
        await db.SaveChangesAsync();

        // return TypedResults.Created($"/api/orders/{newOrderEntity.Id}", new OrderDto(newOrderEntity));
        return TypedResults.Created($"/api/orders/{newOrderEntity.Id}");
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
            ? new ProductDto(entity)
            : null;

    public static async Task<ProductDto[]> AllAsDtos(this DbSet<ProductEntity> products, string? category, string? tag) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Where(x => category == null || x.Category == null || x.Category.Name.ToLower() == category.ToLower())
            .Where(x => tag == null || x.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
            .Select(x => new ProductDto(x))
            .ToArrayAsync();

    public static async Task<OrderDto[]> AllAsDtos(this DbSet<OrderEntity> orders) =>
        await orders.Include(x => x.Customer)
            .Include(x => x.Address)
            .Include(x => x.Status)
            .Include(x => x.Items)
            .Select(x => new OrderDto(x))
            .ToArrayAsync();
}
