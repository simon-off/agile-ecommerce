using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;

namespace MinimalAPI.Handlers;

static class TagsHandler
{
    public static async Task<IResult> GetAll(DataContext db) =>
        TypedResults.Ok(await db.Tags.Select(x => x.Name).ToArrayAsync());
}
