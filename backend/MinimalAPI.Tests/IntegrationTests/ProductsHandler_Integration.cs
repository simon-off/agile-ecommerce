using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Data;
using MinimalAPI.Handlers;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Tests.Helpers;

namespace MinimalAPI.Tests;

[Collection("Database collection")]
public class ProductsHandler_Integration
{
    private readonly DataContext _context;

    public ProductsHandler_Integration(DatabaseFixture fixture)
    {
        _context = fixture.CreateContext();
    }

    [Fact]
    public async void GetAll_ShouldReturnAll()
    {
        var result = (Ok<ProductDTO[]>)await ProductsHandler.GetAll(_context);
        Assert.Equal(4, result.Value?.Length);
    }
}