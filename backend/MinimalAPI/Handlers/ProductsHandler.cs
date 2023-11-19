using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Dtos;
using WebAPI.Models.QueryParameters;

namespace MinimalAPI.Handlers;

public static class ProductsHandler
{
    public static async Task<IResult> GetById(DataContext db, int id) =>
        await db.Products.OneAsDto(id)
        is ProductDTO product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound($"Could not find product with id {id}");

    public static async Task<IResult> GetAll(
        DataContext db,
        string? category = null,
        string? tag = null,
        string? sort = null,
        int? page = null,
        int? amount = null) =>
        TypedResults.Ok(await db.Products.AllAsDtos(GetProductsQueryParameters.Create(category, tag, sort, page, amount)));

    public static async Task<IResult> Count(DataContext db) =>
        TypedResults.Ok(await db.Products.CountAsync());
}
