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
        api.MapGet("/categories", CategoryHandler.GetAll);
        api.MapGet("/tags", TagsHandler.GetAll);
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

static class CategoryHandler
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
}
