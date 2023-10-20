using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class OrderRepo : GenericRepo<OrderEntity>
{
    private readonly DataContext _context;
    public OrderRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<OrderEntity> CreateAsync(OrderEntity entity)
    {
        _context.Orders.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public override async Task<OrderEntity?> GetAsync(Expression<Func<OrderEntity, bool>> predicate)
    {
        return await _context.Orders
            .Include(x => x.Status)
            .Include(x => x.Customer)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .Include(x => x.Items)
            .ThenInclude(x => x.Size)
            .FirstOrDefaultAsync(predicate);
    }

    public override async Task<List<OrderEntity>> GetAllAsync()
    {
        return await _context.Orders
            .Include(x => x.Status)
            .Include(x => x.Customer)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .Include(x => x.Items)
            .ThenInclude(x => x.Size)
            .ToListAsync();
    }

    public override async Task<List<OrderEntity>> GetAllAsync(Expression<Func<OrderEntity, bool>> predicate)
    {
        return await _context.Orders
            .Include(x => x.Status)
            .Include(x => x.Customer)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .Include(x => x.Items)
            .ThenInclude(x => x.Size)
            .Where(predicate)
            .ToListAsync();
    }
}
