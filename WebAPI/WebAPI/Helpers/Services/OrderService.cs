using WebAPI.Helpers.Repositories;
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

    public async Task<OrderDto> PlaceUserOrderAsync(OrderUserCreateSchema schema, string userId)
    {
        var orderEntity = await CreateOrderWithUsersAsync(schema, userId);
        var orderItems = await CreateOrderItemsAsync(schema.Products, orderEntity.Id);

        // Add all the newly created order items to the order so they can be seen in the DTO
        orderEntity.Items = orderItems;

        return orderEntity;
    }

    public async Task<OrderDto> PlaceCustomerOrderAsync(OrderCustomerCreateSchema schema)
    {
        var customer = await _customerService.CreateCustomerAsync(schema.Customer);
        // We don't need to display the address anywhere so it isn't saved
        var address = await _addressService.CreateCustomerAddressAsync(schema.Address, customer.Id);
        var orderEntity = await CreateOrderWithCustomerAsync(schema, customer, address.Id);
        var orderItemEntities = await CreateOrderItemsAsync(schema.Products, orderEntity.Id);

        // Add all the newly created order items to the order so they can be seen in the DTO
        orderEntity.Items = orderItemEntities;

        return orderEntity;
    }

    public async Task<OrderEntity> CreateOrderWithCustomerAsync(OrderCustomerCreateSchema schema, CustomerEntity customer, int addressId)
    {
        var orderEntity = new OrderEntity
        {
            StatusId = 1,
            CustomerId = customer.Id,
            AddressId = addressId,
            OrderComment = schema.OrderComment
        };

        orderEntity.TotalPrice = await CalculateTotalPriceAsync(schema.Products);
        orderEntity = await _orderRepo.CreateAsync(orderEntity);
        // Order gets fetched again to get all includes so it can be converted into DTO
        orderEntity = await _orderRepo.GetAsync(x => x.Id == orderEntity.Id);

        return orderEntity!;
    }

    public async Task<OrderEntity> CreateOrderWithUsersAsync(OrderUserCreateSchema schema, string userId)
    {
        var orderEntity = new OrderEntity
        {
            StatusId = 1,
            UserId = userId,
            AddressId = schema.AddressId,
            OrderComment = schema.OrderComment
        };

        orderEntity.TotalPrice = await CalculateTotalPriceAsync(schema.Products);
        orderEntity = await _orderRepo.CreateAsync(orderEntity);

        return orderEntity;
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

    public async Task<List<OrderItemEntity>> CreateOrderItemsAsync(List<OrderItemSchema> orderItemSchemas, int orderId)
    {
        List<OrderItemEntity> orderItems = new();

        foreach (var orderItemSchema in orderItemSchemas)
        {
            var entity = new OrderItemEntity
            {
                OrderId = orderId,
                ProductId = orderItemSchema.ProductId,
                //SizeId = orderItemSchema.SizeId,
                Quantity = orderItemSchema.Quantity
            };

            entity.SizeId = (await _sizeRepo.GetAsync(x => x.Name == orderItemSchema.Size.ToUpper()))!.Id;

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
