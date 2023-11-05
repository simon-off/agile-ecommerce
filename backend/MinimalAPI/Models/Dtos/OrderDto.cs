using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderDto(
    int Id,
    DateTime OrderDate,
    string? OrderStatus,
    decimal TotalPrice,
    CustomerDto? Customer,
    AddressDto? Address,
    List<OrderItemDto> Items
)
{
    public static OrderDto Create(OrderEntity entity) => new(
        entity.Id,
        entity.OrderDate,
        entity.Status?.Name,
        entity.TotalPrice,
        entity.Customer == null ? null : CustomerDto.Create(entity.Customer),
        entity.Address == null ? null : AddressDto.Create(entity.Address),
        entity.Items.Select(x => OrderItemDto.Create(x)).ToList()
    );
}