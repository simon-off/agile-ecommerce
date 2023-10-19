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
        var products = app.MapGroup("/products");
        products.MapGet("/", ProductsHandler.GetAll);
        products.MapGet("/{id}", ProductsHandler.GetById);
    }
}

static class ProductsHandler
{
    public static async Task<IResult> GetById(DataContext db, int id) =>
        await db.Products.OneInclusive(id)
        is ProductDto product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound();

    public static async Task<IResult> GetAll(DataContext db, [FromQuery] string? category, [FromQuery] string? tag) =>
        await db.Products.AllInclusive(category, tag)
        is List<ProductDto> products && products.Count > 0
        ? TypedResults.Ok(products)
        : TypedResults.NotFound();
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

    public static async Task<List<ProductDto>> AllInclusive(this DbSet<ProductEntity> products, string? category, string? tag) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Where(x => category == null || x.Category.Name.ToLower() == category.ToLower())
            .Where(x => tag == null || x.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
            .Select(x => new ProductDto(x))
            .ToListAsync();
}
