using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record NewOrderDto(
    CustomerDto Customer,
    AddressDto Address,
    List<OrderItemDto> Items
);

public static class NewOrderExtensions
{
    public static OrderEntity CreateEntity(this NewOrderDto _, decimal totalPrice, int customerId, int addressId) => new()
    {
        TotalPrice = totalPrice,
        CustomerId = customerId,
        AddressId = addressId
    };
}