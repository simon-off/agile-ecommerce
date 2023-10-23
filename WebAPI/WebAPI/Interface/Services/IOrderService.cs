using WebAPI.Helpers.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface IOrderService
{
    Task<OrderDto> PlaceCustomerOrderAsync(OrderCustomerCreateSchema schema);
    Task<OrderEntity> CreateOrderWithCustomerAsync(OrderCustomerCreateSchema schema, CustomerEntity customer);
    Task<decimal> CalculateTotalPriceAsync(List<OrderItemSchema> orderItems);
    Task<List<OrderItemEntity>> CreateOrderItemsAsync(List<OrderItemSchema> orderItemSchemas, int orderId);
}
