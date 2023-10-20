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
    private readonly DatabaseFixture _fixture;
    private readonly DataContext _context;
    private readonly ProductRepo _productRepo;
    private readonly ProductService _productService;

    public ProductServiceTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = _fixture.CreateContext();
        _productRepo = new ProductRepo(_context);
        _productService = new ProductService(_productRepo);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        var result = await _productService.GetAllAsync();

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
        List<Expression<Func<ProductEntity, bool>>> filters = new();

        if (!string.IsNullOrWhiteSpace(tagName))
            filters.Add(x =>
                x.Tags.Any(tag => tag.Name.ToLower() == tagName.ToLower()));

        if (!string.IsNullOrWhiteSpace(categoryName))
            filters.Add(x =>
                x.Category.Name.ToLower() == categoryName.ToLower());

        var result = await _productService.GetAllFilteredAsync(filters);

        Assert.Equal(expectedAmount, result.Count);
    }
}