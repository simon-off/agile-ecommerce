using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderItemDto(
    int ProductId,
    int SizeId,
    int Quantity
)
{
    public static OrderItemDto Create(OrderItemEntity entity) => new(
        entity.ProductId,
        entity.SizeId,
        entity.Quantity
    );
}

public static class OrderItemExtensions
{
    public static OrderItemEntity CreateEntity(this OrderItemDto dto, int orderId) => new()
    {
        OrderId = orderId,
        ProductId = dto.ProductId,
        SizeId = dto.SizeId,
        Quantity = dto.Quantity
    };
}