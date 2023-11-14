using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Entities;

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

    public static async Task<ProductDTO[]> AllAsDtos(this DbSet<Product> products, string? category, string? tag) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Where(x => category == null || x.Category == null || x.Category.Name.ToLower() == category.ToLower())
            .Where(x => tag == null || x.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
            .Select(x => ProductDTO.Create(x))
            .ToArrayAsync();

    public static async Task<OrderDTO[]> AllAsDtos(this DbSet<Order> orders, string userId) =>
        await orders
            .Include(x => x.Status)
            .Include(x => x.Items)
            .Where(x => x.UserId == userId)
            .Select(x => OrderDTO.Create(x))
            .ToArrayAsync();
}
