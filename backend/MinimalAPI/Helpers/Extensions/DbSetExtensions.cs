using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Helpers.Extensions;

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
            ? ProductDto.Create(entity)
            : null;

    public static async Task<ProductDto[]> AllAsDtos(this DbSet<ProductEntity> products, string? category, string? tag) =>
        await products
            .Include(x => x.Tags)
            .Include(x => x.AvailableSizes)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Where(x => category == null || x.Category == null || x.Category.Name.ToLower() == category.ToLower())
            .Where(x => tag == null || x.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
            .Select(x => ProductDto.Create(x))
            .ToArrayAsync();

    public static async Task<OrderDto[]> AllAsDtos(this DbSet<OrderEntity> orders) =>
        await orders
            .Include(x => x.Customer)
            .Include(x => x.Address)
            .Include(x => x.Status)
            .Include(x => x.Items)
            .Select(x => OrderDto.Create(x))
            .ToArrayAsync();
}
