using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPITest.Helpers;

namespace WebAPITest.IntegrationTests.ServiceTests;

[Collection("Database collection")]
public class ProductService_Integration
{
    private readonly DataContext _context;
    private readonly ProductRepo _productRepo;
    private readonly ProductService _productService;

    public ProductService_Integration(DatabaseFixture fixture)
    {
        _context = fixture.CreateContext();
        _productRepo = new ProductRepo(_context);
        _productService = new ProductService(_productRepo);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        // Assert is performed in the seed
        // Act
        var result = await _productService.GetAllAsync();

        // Assert
        Assert.Equal(4, result.Count);
    }

    [Theory]
    // Test only categories
    [InlineData("Pants", null, 2)]
    [InlineData("Shoes", "", 0)]
    [InlineData("MadeUpCategory", "", 0)]
    // Test only tags
    [InlineData("", "Kids", 1)]
    [InlineData(null, "Unisex", 1)]
    [InlineData(null, "Featured", 4)]
    // Categories and tags
    [InlineData("Shirts", "Kids", 0)]
    [InlineData("Pants", "Unisex", 1)]
    [InlineData("Shirts", "Sport", 1)]
    public async Task GetAllAsync_ShouldReturnAllRelevantProducts(string categoryName, string tagName, int expectedAmount)
    {
        // Act
        var result = await _productService.GetAllAsync(tagName, categoryName);

        // Assert
        Assert.Equal(expectedAmount, result.Count);
    }

    [Theory]
    // Test orderBy
    [InlineData("lowestprice", 2)]
    [InlineData("highestprice", 3)]
    public async Task GetAllAsync_ShouldReturnOrderedProducts(string orderBy, int expectedFirstProductId)
    {
        // Act
        var result = await _productService.GetAllAsync(orderBy: orderBy);

        // Assert
        Assert.Equal(expectedFirstProductId, result.First().Id);
    }
}