using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Data;
using MinimalAPI.Handlers;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Tests.Helpers;

namespace MinimalAPI.Tests.UnitTests;

[Collection("Database collection")]
public class ProductsHandler_Unit
{
    private readonly DataContext _context;

    public ProductsHandler_Unit(DatabaseFixture fixture)
    {
        _context = fixture.GetContext();
    }

    [Fact]
    public async void GetAll_ShouldReturnAll()
    {
        // Act
        var result = (Ok<ProductDTO[]>)await ProductsHandler.GetAll(_context);

        // Assert
        Assert.Equal(3, result.Value?.Length);
        Assert.Equal("Red Pants", result.Value?[0].Name);
    }

    [Fact]
    public async void GetById_ShouldReturnSpecific()
    {
        // Act
        var result = (Ok<ProductDTO>)await ProductsHandler.GetById(_context, 1);

        // Assert
        Assert.True(result.Value is
        {
            Id: 1,
            Name: "Red Pants",
            Description: "A pair of red pants.",
            Category: "Pants",
            Price: 59.99m,
            AvailableSizes.Count: 3,
            Tags.Count: 1
        });
    }

    [Fact]
    public async void Count_ShouldReturnAmount()
    {
        // Act
        var result = (Ok<int>)await ProductsHandler.Count(_context);

        // Assert
        Assert.Equal(3, result.Value);
    }
}