using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Handlers;

static class OrdersHandler
{
    public static async Task<IResult> GetAll(DataContext db) =>
        TypedResults.Ok(await db.Orders.AllAsDtos());

    public static async Task<IResult> Create(DataContext db, OrderCreateDTO newOrderDto)
    {
        decimal totalPrice = 0m;

        foreach (var item in newOrderDto.Items)
        {
            var productEntity = await db.Products
                .Include(x => x.AvailableSizes)
                .FirstOrDefaultAsync(x => x.Id == item.ProductId && x.AvailableSizes.Any(s => s.Id == item.SizeId));

            if (productEntity is null)
            {
                return TypedResults.NotFound($"Product with id: {item.ProductId} and size id: {item.SizeId} could not be found in the database");
            }
            totalPrice = productEntity.Price * item.Quantity;
        }

        var newOrderEntity = newOrderDto.ConvertToEntity(totalPrice);
        await db.Orders.AddAsync(newOrderEntity);
        await db.SaveChangesAsync();

        foreach (var item in newOrderDto.Items)
        {
            await db.OrderItems.AddAsync(item.ConvertToEntity(newOrderEntity.Id));
        }
        await db.SaveChangesAsync();

        return TypedResults.Created($"/api/orders/{newOrderEntity.Id}", OrderDTO.Create(newOrderEntity));
    }
}
