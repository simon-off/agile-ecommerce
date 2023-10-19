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
        var products = app.MapGroup("/products");

        products.MapGet("/", async (DataContext context) =>
        {
            var stuff = await context.Products.FirstAsync(x => x.Id == 1);
            var dto = new ProductDto(stuff);
            return dto;
        });
        // products.MapGet("/{id}", ProductsHandler.GetById);
        // products.MapGet("/", async (DataContext context) => await context.Tags.Select(x => x.Name).ToListAsync());
    }
}

public static class ProductsHandler
{

    public static async Task<List<ProductDto>> AllWithEverythingIncluded(this DbSet<ProductEntity> products)
    {
        var productEntities = await products
                .Include(x => x.Tags)
                .Include(x => x.AvailableSizes)
                .Include(x => x.Images)
                .ToListAsync();

        var dtos = new List<ProductDto>();

        foreach (var entity in productEntities)
        {
            if (entity is not null)
                dtos.Add(new ProductDto(entity));
        }

        return dtos;
    }
}
