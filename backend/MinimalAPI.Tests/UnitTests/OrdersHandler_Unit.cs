using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Handlers;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Identity;
using MinimalAPI.Tests.Helpers;
using Moq;

namespace MinimalAPI.Tests.UnitTests;

[Collection("Database collection")]
public class OrdersHandler_Unit
{
    private readonly DataContext _context;

    public OrdersHandler_Unit(DatabaseFixture fixture)
    {
        _context = fixture.GetContext();
    }

    // [Theory]
    // [InlineData(typeof(Created<OrderDTO>), 1, 1)]
    // [InlineData(typeof(BadRequest<string>), 1, 1, 2)]
    // [InlineData(typeof(BadRequest<string>), 0, 1)]
    // [InlineData(typeof(BadRequest<string>), 1, 0)]
    // public async void Create_ReturnsCreatedOrBadRequest(Type expectedType, int productId, int sizeId, int itemCopies = 1)
    // {
    //     // Arrange
    //     var orderItems = Enumerable
    //         .Range(0, itemCopies)
    //         .Select(_ => new OrderItemDTO(productId, sizeId, 1))
    //         .ToList();

    //     var dto = new OrderCreateDTO(
    //         "John",
    //         "Doe",
    //         "john@domain.com",
    //         "1234567890",
    //         "123 Main St",
    //         "12345",
    //         "New York",
    //         orderItems
    //     );

    //     // Act
    //     var result = await OrdersHandler.Create(_request, _context, _userManager, dto);

    //     // Assert
    //     Assert.IsAssignableFrom(expectedType, result);

    //     if (result is Created<OrderDTO> created)
    //     {
    //         Assert.Equal(dto.FirstName, created.Value?.FirstName);
    //         Assert.Equal(dto.LastName, created.Value?.LastName);
    //         Assert.Equal(dto.Email, created.Value?.Email);
    //         Assert.Equal(dto.PhoneNumber, created.Value?.PhoneNumber);
    //         Assert.Equal(dto.StreetAddress, created.Value?.StreetAddress);
    //         Assert.Equal(dto.PostalCode, created.Value?.PostalCode);
    //         Assert.Equal(dto.City, created.Value?.City);
    //         Assert.Equal(1, created.Value?.Items.Count);
    //     }
    // }

    // [Fact]
    // public async void Create_CalculatesPriceCorrectly()
    // {
    //     // Arrange
    //     var dto = new OrderCreateDTO(
    //         "John",
    //         "Doe",
    //         "john@domain.com",
    //         "1234567890",
    //         "123 Main St",
    //         "12345",
    //         "New York",
    //         new List<OrderItemDTO>
    //         {
    //             new(1, 1, 1),
    //             new(2, 1, 2),
    //             new(3, 1, 3),
    //         }
    //     );
    //     var expectedPrice = 59.99m + (19.99m * 2) + (69.99m * 3);

    //     // Act
    //     var result = (Created<OrderDTO>)await OrdersHandler.Create(_request, _context, _userManager, dto);

    //     // Assert
    //     Assert.Equal(expectedPrice, result.Value?.TotalPrice);
    // }
}