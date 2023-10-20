using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class ProductRepo : GenericRepo<ProductEntity>
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

    public override async Task<List<ProductEntity>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .ToListAsync();
    }

    public override async Task<List<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _context.Products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .Where(predicate)
            .ToListAsync();
    }
    public async Task<List<ProductEntity>> GetAllAsync(List<Expression<Func<ProductEntity, bool>>> predicates)
    {
        var query = _context.Products
            .Include(x => x.Tags)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.AvailableSizes)
            .AsQueryable();
            
        // Loops through all filters to make it possible to use multiple predicates in one method
        foreach (var predicate in predicates)
            query = query.Where(predicate);

        return await query.ToListAsync();
    }

}
