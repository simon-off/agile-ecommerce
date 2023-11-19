using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Entities;
using WebAPI.Models.QueryParameters;

namespace MinimalAPI.Extensions;

static class DbSetExtensions
{
    public static async Task<ProductDTO?> OneAsDto(this DbSet<Product> products, int id) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id)
            is Product entity
            ? ProductDTO.Create(entity)
            : null;

    public static async Task<ProductDTO[]> AllAsDtos(this DbSet<Product> products, GetProductsQueryParameters qp)
    {
        var query = products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .Where(x => string.IsNullOrWhiteSpace(qp.Tag) || x.Tags.Any(t => t.Name.ToLower() == qp.Tag.ToLower()))
            .Where(x => string.IsNullOrWhiteSpace(qp.Category) || x.Category != null && x.Category.Name.ToLower() == qp.Category.ToLower())
            .AsQueryable();

        query = qp.Sort?.ToLower() switch
        {
            "lowestprice" => query.OrderBy(x => (double)x.Price),
            "highestprice" => query.OrderByDescending(x => (double)x.Price),
            _ => query.Select(x => x)
        };

        // This makes sure the pagination happens after products are ordered
        query = query
            .Skip(qp.Page - 1 * qp.Amount)
            .Take(qp.Amount);

        return await query.Select(x => ProductDTO.Create(x)).ToArrayAsync();
    }

    public static async Task<OrderDTO[]> AllAsDtos(this DbSet<Order> orders, string userId) =>
        await orders
            .Include(x => x.Status)
            .Include(x => x.Items)
            .Where(x => x.UserId == userId)
            .Select(x => OrderDTO.Create(x))
            .ToArrayAsync();
}
