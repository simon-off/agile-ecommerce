using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPITest.Helpers;

namespace WebAPITest.ServiceTests;

[Collection("Database collection")]
public class CategoryServiceTests
{
    private readonly DatabaseFixture _fixture;
    private readonly DataContext _context;
    private readonly CategoryRepo _categoryRepo;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.CreateContext();
        _categoryRepo = new CategoryRepo(_context);
        _categoryService = new CategoryService(_categoryRepo);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCategories()
    {
        var result = await _categoryService.GetAllAsync();

        Assert.Equal(3, result.Count);
    }
}
