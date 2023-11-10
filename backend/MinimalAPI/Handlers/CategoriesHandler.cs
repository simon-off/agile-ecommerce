using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;

namespace MinimalAPI.Handlers;

static class CategoriesHandler
{
    public static async Task<IResult> GetAll(DataContext db) =>
        TypedResults.Ok(await db.Categories.Select(x => x.Name).ToArrayAsync());
}
