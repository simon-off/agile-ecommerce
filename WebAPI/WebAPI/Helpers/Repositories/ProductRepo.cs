using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class ProductRepo : GenericRepo<ProductEntity>, IProductRepo
{
    private readonly DataContext _context;

    public ProductRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ProductEntity?> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _context.Products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<List<ProductEntity>> GetAllAsync(string? tagName, string? categoryName, string? orderBy)
    {
        var query = _context.Products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .Where(x => string.IsNullOrWhiteSpace(tagName) || x.Tags.Any(t => t.Name.ToLower() == tagName.ToLower()))
            .Where(x => string.IsNullOrWhiteSpace(categoryName) || x.Category.Name.ToLower() == categoryName.ToLower())
            .AsQueryable();

        query = orderBy?.ToLower() switch
        {
            "lowestprice" => query.OrderBy(x => (double)x.Price),
            "highestprice" => query.OrderByDescending(x => (double)x.Price),
            _ => query.Select(x => x)
        };

        return await query.ToListAsync();
    }
}
