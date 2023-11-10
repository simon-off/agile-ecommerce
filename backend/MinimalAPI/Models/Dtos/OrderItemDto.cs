using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderItemDTO(
    int ProductId,
    int SizeId,
    int Quantity
)
{
    public static OrderItemDTO Create(OrderItem entity) => new(
        entity.ProductId,
        entity.SizeId,
        entity.Quantity
    );
}

public static class OrderItemDTOExtensions
{
    public static OrderItem ConvertToEntity(this OrderItemDTO dto, int orderId) => new()
    {
        OrderId = orderId,
        ProductId = dto.ProductId,
        SizeId = dto.SizeId,
        Quantity = dto.Quantity
    };
}
