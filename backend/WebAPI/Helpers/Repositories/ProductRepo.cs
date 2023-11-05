using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;
using WebAPI.Models.QueryParameters;

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

    public async Task<List<ProductEntity>> GetAllAsync(GetProductsQueryParameters qp)
    {
        var query = _context.Products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .Where(x => string.IsNullOrWhiteSpace(qp.TagName) || x.Tags.Any(t => t.Name.ToLower() == qp.TagName.ToLower()))
            .Where(x => string.IsNullOrWhiteSpace(qp.CategoryName) || x.Category.Name.ToLower() == qp.CategoryName.ToLower())
            .AsQueryable();

        query = qp.OrderBy?.ToLower() switch
        {
            "lowestprice" => query.OrderBy(x => (double)x.Price),
            "highestprice" => query.OrderByDescending(x => (double)x.Price),
            _ => query.Select(x => x)
        };

        // This makes sure the pagination happens after products are ordered
        query = query
            .Skip(qp.Page > 0 ? (qp.Page - 1) * qp.PageAmount : 0)
            .Take(qp.PageAmount > 0 ? qp.PageAmount : 32);

        return await query.ToListAsync();
    }

    public async Task<int> GetProductCount(string? tagName, string? categoryName)
    {
        return await _context.Products
            .Where(x => string.IsNullOrWhiteSpace(tagName) || x.Tags.Any(t => t.Name.ToLower() == tagName.ToLower()))
            .Where(x => string.IsNullOrWhiteSpace(categoryName) || x.Category.Name.ToLower() == categoryName.ToLower())
            .CountAsync();
    }
}
