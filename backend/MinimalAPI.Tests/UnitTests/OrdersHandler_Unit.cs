using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Data;
using MinimalAPI.Handlers;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Tests.Helpers;

namespace MinimalAPI.Tests.UnitTests;

[Collection("Database collection")]
public class OrdersHandler_Unit
{
    private readonly DataContext _context;

    public OrdersHandler_Unit(DatabaseFixture fixture)
    {
        _context = fixture.GetContext();
    }

    [Fact]
    public async void Create_ShouldReturnCreated()
    {
        var dto = new OrderCreateDTO(
            "John",
            "Doe",
            "john@domain.com",
            "1234567890",
            "123 Main St",
            "12345",
            "New York",
            new List<OrderItemDTO>
            {
                new(1, 1, 1),
                new(2, 2, 2),
                new(3, 3, 3),
            }
        );

        var created = (Created<OrderDTO>)await OrdersHandler.Create(_context, dto);

        Assert.True(created.Value is
        {
            FirstName: "John",
            LastName: "Doe",
            Email: "john@domain.com",
            PhoneNumber: "1234567890",
            StreetAddress: "123 Main St",
            PostalCode: "12345",
            City: "New York",
            Items.Count: 3
        });
    }

    [Theory]
    [InlineData(typeof(Created<OrderDTO>), 1, 1)]
    [InlineData(typeof(NotFound<string>), 0, 1)]
    [InlineData(typeof(NotFound<string>), 1, 0)]
    public async void Create_ShouldReturnNotFound(Type expected, int productId, int sizeId)
    {
        var dto = new OrderCreateDTO(
            "John",
            "Doe",
            "john@domain.com",
            "1234567890",
            "123 Main St",
            "12345",
            "New York",
            new List<OrderItemDTO>
            {
                new(productId, sizeId, 1),
            }
        );

        var result = await OrdersHandler.Create(_context, dto);

        Assert.IsAssignableFrom(expected, result);
    }
}