using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderItemDto(
    int ProductId,
    int SizeId,
    int Quantity
)
{
    public OrderItemDto(OrderItemEntity entity) : this(
        entity.ProductId,
        entity.SizeId,
        entity.Quantity
    )
    { }
}