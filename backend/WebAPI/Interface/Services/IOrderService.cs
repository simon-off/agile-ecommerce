using WebAPI.Helpers.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface IOrderService
{
    Task<OrderDto> PlaceCustomerOrderAsync(OrderCustomerCreateSchema schema);
    Task<OrderDto> PlaceUserOrderAsync(OrderUserCreateSchema schema, string userId);
    Task<OrderEntity> CreateOrderWithCustomerAsync(OrderCustomerCreateSchema schema, CustomerEntity customer, int addressId);
    Task<OrderEntity> CreateOrderWithUsersAsync(OrderUserCreateSchema schema, string userId);
    Task<decimal> CalculateTotalPriceAsync(List<OrderItemSchema> orderItems);
    Task<List<OrderItemEntity>> CreateOrderItemsAsync(List<OrderItemSchema> orderItemSchemas, int orderId);
    Task<bool> AllProductItemsValidAsync(List<OrderItemSchema> items);
    Task<List<OrderDto>> GetAllUserOrders(string userId);
}
