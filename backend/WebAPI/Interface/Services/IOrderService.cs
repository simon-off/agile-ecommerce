using WebAPI.Helpers.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface IOrderService
{
    Task<OrderDto> PlaceOrderAsync(OrderCreateSchema schema, string? userId);
    Task<OrderEntity> CreateOrderAsync(OrderCreateSchema schema, int customerId, int addressId, string? userId);
    Task<decimal> CalculateTotalPriceAsync(List<OrderItemSchema> orderItems);
    Task<List<OrderItemEntity>> CreateOrderItemsAsync(List<OrderItemSchema> orderItemSchemas, int orderId);
    Task<bool> AllProductItemsValidAsync(List<OrderItemSchema> items);
    Task<List<OrderDto>> GetAllUserOrders(string userId);
}
