using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Identity;

namespace MinimalAPI.Handlers;

public static class OrdersHandler
{
    public static async Task<IResult> GetAll(HttpRequest request, DataContext db, UserManager<User> userManager)
    {
        var userId = await userManager.Users
            .Where(x => x.Id == request.GetUserId())
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        return userId is null
            ? TypedResults.Unauthorized()
            : TypedResults.Ok(await db.Orders.AllAsDtos(userId));
    }

    public static async Task<IResult> Create(HttpRequest request, DataContext db, UserManager<User> userManager, OrderCreateDTO dto)
    {
        decimal totalPrice = 0m;

        foreach (var item in dto.Items)
        {
            var productEntity = await db.Products
                .Include(x => x.AvailableSizes)
                .FirstOrDefaultAsync(x => x.Id == item.ProductId && x.AvailableSizes.Any(s => s.Id == item.SizeId));

            if (productEntity is null)
                return TypedResults.BadRequest($"Product with id: {item.ProductId} and size id: {item.SizeId} could not be found in the database");

            var copies = dto.Items.Where(x => x.ProductId == item.ProductId && x.SizeId == item.SizeId);

            if (copies.Count() > 1)
                return TypedResults.BadRequest($"Product with id: {item.ProductId} and size id: {item.SizeId} is duplicated in the order");

            totalPrice += productEntity.Price * item.Quantity;
        }

        // Check if there's a user logged in
        string? userId = null;
        if (request.Headers.Authorization.FirstOrDefault() is not null)
        {
            userId = (await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.GetUserId()))?.Id;

            if (userId is null)
                return TypedResults.BadRequest("Invalid auth token");
        }

        var newOrderEntity = dto.ConvertToEntity(totalPrice);
        newOrderEntity.UserId = userId;

        await db.Orders.AddAsync(newOrderEntity);
        await db.SaveChangesAsync();

        foreach (var item in dto.Items)
        {
            await db.OrderItems.AddAsync(item.ConvertToEntity(newOrderEntity.Id));
        }
        await db.SaveChangesAsync();

        return TypedResults.Created($"/api/orders/{newOrderEntity.Id}", OrderDTO.Create(newOrderEntity));
    }
}
