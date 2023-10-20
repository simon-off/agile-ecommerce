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
        app.MapGet("/products/", ProductsHandler.GetAll);
        app.MapGet("/products/{id}", ProductsHandler.GetById);
        // app.MapGet("/categories", CategoryHandler.GetAll);
    }
}

static class ProductsHandler
{
    public static async Task<Results<Ok<ProductDto>, NotFound>> GetById(DataContext db, int id) =>
        await db.Products.OneInclusive(id)
        is ProductDto product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound();

    public static async Task<Results<Ok<ProductDto[]>, NotFound>> GetAll(DataContext db, [FromQuery] string? category, [FromQuery] string? tag) =>
        await db.Products.AllInclusive(category, tag)
        is ProductDto[] products && products.Length > 0
        ? TypedResults.Ok(products)
        : TypedResults.NotFound();
}

static class CategoryHandler
{

}

static class DbSetExtensions
{
    public static async Task<ProductDto?> OneInclusive(this DbSet<ProductEntity> products, int id) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id)
            is ProductEntity entity
            ? new ProductDto(entity)
            : null;

    public static async Task<ProductDto[]> AllInclusive(this DbSet<ProductEntity> products, string? category, string? tag) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Where(x => category == null || x.Category.Name.ToLower() == category.ToLower())
            .Where(x => tag == null || x.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
            .Select(x => new ProductDto(x))
            .ToArrayAsync();
}
