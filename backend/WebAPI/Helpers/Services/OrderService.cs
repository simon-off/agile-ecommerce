using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Helpers.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepo _orderRepo;
    private readonly ICustomerService _customerService;
    private readonly IOrderItemRepo _orderItemRepo;
    private readonly IProductRepo _productRepo;
    private readonly IAddressService _addressService;
    private readonly ISizeRepo _sizeRepo;

    public OrderService(IOrderRepo orderRepo, ICustomerService customerService, IOrderItemRepo orderItemRepo, IProductRepo productRepo, IAddressService addressService, ISizeRepo sizeRepo)
    {
        _orderRepo = orderRepo;
        _customerService = customerService;
        _orderItemRepo = orderItemRepo;
        _productRepo = productRepo;
        _addressService = addressService;
        _sizeRepo = sizeRepo;
    }

    public async Task<OrderDto> PlaceOrderAsync(OrderCreateSchema schema, string? userId)
    {
        var customer = await _customerService.CreateCustomerAsync(schema.Customer);
        var address = await _addressService.CreateAddressAsync(schema.Address, customer.Id, userId);
        var orderEntity = await CreateOrderAsync(schema, customer.Id, address.Id, userId);
        var orderItemEntities = await CreateOrderItemsAsync(schema.Products, orderEntity.Id);

        // Add all the newly created order items to the order so they can be seen in the DTO
        orderEntity.Items = orderItemEntities;

        return orderEntity;
    }

    public async Task<OrderEntity> CreateOrderAsync(OrderCreateSchema schema, int customerId, int addressId, string? userId)
    {
        var orderEntity = new OrderEntity
        {
            StatusId = 1,
            CustomerId = customerId,
            AddressId = addressId,
            UserId = userId,
            OrderComment = schema.OrderComment,
            TotalPrice = await CalculateTotalPriceAsync(schema.Products)
        };

        return await _orderRepo.CreateAsync(orderEntity);
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

            totalPrice += product.Price * orderItem.Quantity;
        }

        return totalPrice;
    }

    public async Task<List<OrderItemEntity>> CreateOrderItemsAsync(List<OrderItemSchema> orderItemSchemas, int orderId)
    {
        List<OrderItemEntity> orderItems = new();

        foreach (var orderItemSchema in orderItemSchemas)
        {
            var entity = new OrderItemEntity
            {
                OrderId = orderId,
                ProductId = orderItemSchema.ProductId,
                Quantity = orderItemSchema.Quantity,
                SizeId = (await _sizeRepo.GetAsync(x => x.Name == orderItemSchema.Size.ToUpper()))!.Id
            };

            entity = await _orderItemRepo.CreateAsync(entity);

            orderItems.Add(entity);
        }

        return orderItems;
    }

    public async Task<bool> AllProductItemsValidAsync(List<OrderItemSchema> items)
    {
        foreach (var item in items)
        {
            var isValidProduct = await _productRepo.AnyAsync(x => x.Id == item.ProductId);
            var isValidProductSize = await _productRepo.AnyAsync(x => x.Id == item.ProductId && x.AvailableSizes.Any(x => x.Name.ToLower() == item.Size.ToLower()));

            if (!isValidProduct || !isValidProductSize)
                return false;
        }

        return true;
    }

    public async Task<List<OrderDto>> GetAllUserOrders(string userId)
    {
        var dtos = new List<OrderDto>();
        var entities = await _orderRepo.GetAllAsync(x => x.UserId == userId);

        foreach (var entity in entities)
            dtos.Add(entity);

        return dtos;
    }
}
