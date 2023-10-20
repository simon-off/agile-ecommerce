using WebAPI.Helpers.Repositories;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Helpers.Services;

public class OrderService
{
    private readonly OrderRepo _orderRepo;
    private readonly CustomerService _customerService;
    private readonly OrderItemRepo _orderItemRepo;
    private readonly ProductRepo _productRepo;
    private readonly AddressService _addressService;

    public OrderService(OrderRepo orderRepo, CustomerService customerService, OrderItemRepo orderItemRepo, ProductRepo productRepo, AddressService addressService)
    {
        _orderRepo = orderRepo;
        _customerService = customerService;
        _orderItemRepo = orderItemRepo;
        _productRepo = productRepo;
        _addressService = addressService;
    }

    public async Task<OrderDto> PlaceCustomerOrderAsync(OrderCustomerCreateSchema schema)
    {
        var customer = await _customerService.CreateCustomerAsync(schema.Customer);
        // We don't need to display the address anywhere so it isn't saved
        await _addressService.CreateCustomerAddressAsync(schema.Address, customer.Id);
        var orderEntity = await CreateOrderWithCustomerAsync(schema, customer);
        var orderItemEntities = await CreateOrderItemsAsync(schema.Products, orderEntity.Id);

        // Add all the newly created order items to the order so they can be seen in the DTO
        orderEntity.Items = orderItemEntities;

        return orderEntity;
    }

    private async Task<OrderEntity> CreateOrderWithCustomerAsync(OrderCustomerCreateSchema schema, CustomerEntity customer)
    {
        var orderEntity = new OrderEntity
        {
            StatusId = 1,
            CustomerId = customer.Id,
        };

        orderEntity.TotalPrice = await CalculateTotalPriceAsync(schema.Products);
        // Add to database here since all the required information has been calculated
        orderEntity = await _orderRepo.CreateAsync(orderEntity);
        // Order gets fetched again to get all includes so it can be converted into DTO
        orderEntity = await _orderRepo.GetAsync(x => x.Id == orderEntity.Id);

        return orderEntity!;
    }

    public async Task<decimal> CalculateTotalPriceAsync(List<OrderItemSchema> orderItems)
    {
        decimal totalPrice = 0;

        foreach (var orderItem in orderItems)
        {
            var product = await _productRepo.GetAsync(x => x.Id == orderItem.ProductId);

            // If product is null the order data is incorrect and the order should be refused
            if (product == null)
                throw new Exception();

            totalPrice += (product.Price * orderItem.Quantity);
        }

        return totalPrice;
    }

    private async Task<List<OrderItemEntity>> CreateOrderItemsAsync(List<OrderItemSchema> orderItemSchemas, int orderId)
    {
        List<OrderItemEntity> orderItems = new();

        foreach (var orderItemSchema in orderItemSchemas)
        {
            var entity = new OrderItemEntity
            {
                OrderId = orderId,
                ProductId = orderItemSchema.ProductId,
                SizeId = orderItemSchema.SizeId,
                Quantity = orderItemSchema.Quantity
            };

            entity = await _orderItemRepo.CreateAsync(entity);

            orderItems.Add(entity);
        }

        return orderItems;
    }
}
