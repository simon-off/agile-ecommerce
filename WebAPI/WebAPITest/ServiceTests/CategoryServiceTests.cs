using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPITest.Helpers;

namespace WebAPITest.ServiceTests;

[Collection("Database collection")]
public class CategoryServiceTests
{
    private readonly DataContext _context;
    private readonly CategoryRepo _categoryRepo;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests(DatabaseFixture fixture)
    {
        _context = fixture.CreateContext();
        _categoryRepo = new CategoryRepo(_context);
        _categoryService = new CategoryService(_categoryRepo);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCategories()
    {
        // Assert is technically performed in the seed
        // Act
        var result = await _categoryService.GetAllAsync();

        // Assert
        Assert.Equal(3, result.Count);
    }
}
