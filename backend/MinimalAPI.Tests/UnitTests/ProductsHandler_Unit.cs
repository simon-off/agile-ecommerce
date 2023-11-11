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
        var result = (Ok<ProductDTO[]>)await ProductsHandler.GetAll(_context);

        Assert.Equal(3, result.Value?.Length);
        Assert.Equal("Red Pants", result.Value?[0].Name);
    }
}