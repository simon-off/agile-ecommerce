using Moq;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPITest.UnitTests.ServiceTests;

public class Category_Unit
{
    private readonly Mock<ICategoryRepo> _mockCategoryRepo;
    private readonly CategoryService _categoryService;

    public Category_Unit()
    {
        _mockCategoryRepo = new Mock<ICategoryRepo>();
        _categoryService = new CategoryService(_mockCategoryRepo.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCategories()
    {
        // Arrange
        var response = new List<CategoryEntity>
        {
            new CategoryEntity
            {
                Id = 1,
                Name = "Category 1"
            },
            new CategoryEntity
            {
                Id = 2,
                Name = "Category 2"
            },
            new CategoryEntity
            {
                Id = 3,
                Name = "Category 3"
            }
        };
        _mockCategoryRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(response);

        // Act
        var result = await _categoryService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(2, result[1].Id);
        Assert.Equal(3, result[2].Id);
        Assert.Equal("Category 1", result[0].Name);
        Assert.Equal("Category 2", result[1].Name);
        Assert.Equal("Category 3", result[2].Name);
    }
}
