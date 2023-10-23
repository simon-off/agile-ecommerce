using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Models.Schemas;
using WebAPITest.Helpers;

namespace WebAPITest.IntegrationTests.ServiceTests;

[Collection("Database collection")]
public class OrderService_Integration
{
    private readonly DataContext _context;
    private readonly OrderRepo _orderRepo;
    private readonly OrderService _orderService;

    public OrderService_Integration(DatabaseFixture fixture)
    {
        _context = fixture.CreateContext();
        _orderRepo = new OrderRepo(_context);
        _orderService = new OrderService(
            _orderRepo,
            new CustomerService(new CustomerRepo(_context)),
            new OrderItemRepo(_context), new ProductRepo(_context),
            new AddressService(new AddressRepo(_context)));
    }

    [Fact]
    public async Task CalculateTotalPriceAsync_ShouldCalculateTotalPrice()
    {
        // Arrange 
        var productOrderItems = new List<OrderItemSchema>()
        {
             new OrderItemSchema
             {
                 ProductId = 1,
                 SizeId = 1,
                 Quantity = 2,
             },
             new OrderItemSchema
             {
                 ProductId = 4,
                 SizeId = 3,
                 Quantity = 5,
             }
        };

        // Act
        var actualValue = await _orderService.CalculateTotalPriceAsync(productOrderItems);

        // Assert
        var expectedPrice = 419.93m;
        Assert.Equal(expectedPrice, actualValue);
    }
}


