namespace MinimalAPI.Models.Dtos;

public record NewOrderDto(
    CustomerDto Customer,
    AddressDto Address,
    List<OrderItemDto> Items
);
