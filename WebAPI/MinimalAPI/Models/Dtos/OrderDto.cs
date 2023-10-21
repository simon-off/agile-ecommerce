using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderDto(
    DateTime OrderDate,
    string? OrderStatus,
    decimal TotalPrice,
    CustomerDto? Customer,
    AddressDto? Address,
    List<OrderItemDto> Items
)
{
    public OrderDto(OrderEntity entity) : this(
        entity.OrderDate,
        entity.Status?.Name,
        entity.TotalPrice,
        entity.Customer == null ? null : new CustomerDto(entity.Customer),
        entity.Customer == null || entity.Customer.Address == null ? null : new AddressDto(entity.Customer.Address),
        entity.Items.Select(x => new OrderItemDto(x)).ToList()
        )
    { }
}