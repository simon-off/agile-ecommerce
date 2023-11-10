using MinimalAPI.Data;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Handlers;

static class ProductsHandler
{
    public static async Task<IResult> GetById(DataContext db, int id) =>
        await db.Products.OneAsDto(id)
        is ProductDTO product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound($"Could not find product with id {id}");

    public static async Task<IResult> GetAll(DataContext db, string? category, string? tag) =>
        TypedResults.Ok(await db.Products.AllAsDtos(category, tag));
}
