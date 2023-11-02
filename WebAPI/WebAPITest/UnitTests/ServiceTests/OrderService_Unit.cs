using Moq;
using System.Linq.Expressions;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPITest.UnitTests.ServiceTests;

public class OrderService_Unit
{
    private readonly Mock<IOrderRepo> _mockOrderRepo;
    private readonly Mock<ICustomerService> _mockCustomerService;
    private readonly Mock<IOrderItemRepo> _mockorderItemRepo;
    private readonly Mock<IProductRepo> _mockProductRepo;
    private readonly Mock<IAddressService> _mockAddressService;
    private readonly Mock<ISizeRepo> _mockSizeRepo;
    private readonly OrderService _orderService;

    public OrderService_Unit()
    {
        _mockOrderRepo = new Mock<IOrderRepo>();
        _mockCustomerService = new Mock<ICustomerService>();
        _mockorderItemRepo = new Mock<IOrderItemRepo>();
        _mockProductRepo = new Mock<IProductRepo>();
        _mockAddressService = new Mock<IAddressService>();
        _mockSizeRepo = new Mock<ISizeRepo>();
        _orderService = new OrderService(
            _mockOrderRepo.Object,
            _mockCustomerService.Object,
            _mockorderItemRepo.Object,
            _mockProductRepo.Object,
            _mockAddressService.Object,
            _mockSizeRepo.Object
            );
    }

    [Fact]
    public async Task CalculateTotalPriceAsync_ShouldReturnTotalPrice()
    {
        // Arrange 
        var productOrderItems = new List<OrderItemSchema>()
        {
             new OrderItemSchema
             {
                 ProductId = 1,
                 Size = "S",
                 Quantity = 2,
             },
             new OrderItemSchema
             {
                 ProductId = 4,
                 Size = "XL",
                 Quantity = 5,
             }
        };
        var response = new ProductEntity
        {
            Id = 1,
            Name = "Red Pants",
            Description = "A pair of red pants.",
            CategoryId = 1,
            Price = 59.99m,
        };

        var expectedPrice = 419.93m;

        _mockProductRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(response);

        // Act
        var result = await _orderService.CalculateTotalPriceAsync(productOrderItems);

        // Assert
        Assert.Equal(expectedPrice, result);
    }
}
