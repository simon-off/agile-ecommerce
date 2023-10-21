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