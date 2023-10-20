using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Models.Entities;
using WebAPITest.Helpers;

namespace WebAPITest.ServiceTests;

[Collection("Database collection")]
public class ProductServiceTests
{
    private readonly DataContext _context;
    private readonly ProductRepo _productRepo;
    private readonly ProductService _productService;

    public ProductServiceTests(DatabaseFixture fixture)
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
    public async Task GetAllFilteredAsync_ShouldReturnAllRelevantProducts(string categoryName, string tagName, int expectedAmount)
    {
        // Assert
        List<Expression<Func<ProductEntity, bool>>> filters = new();

        // Add tag based filtering if query isn't empty
        if (!string.IsNullOrWhiteSpace(tagName))
            filters.Add(x =>
                x.Tags.Any(tag => tag.Name.ToLower() == tagName.ToLower()));

        // Add category based filtering if query isn't empty
        if (!string.IsNullOrWhiteSpace(categoryName))
            filters.Add(x =>
                x.Category.Name.ToLower() == categoryName.ToLower());

        // Act
        var result = await _productService.GetAllFilteredAsync(filters);

        // Assert
        Assert.Equal(expectedAmount, result.Count);
    }
}