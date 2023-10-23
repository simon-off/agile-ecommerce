using Moq;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPITest.UnitTests.ServiceTests;

public class ProductService_Unit
{
    private readonly Mock<IProductRepo> _mockProductRepo;
    private readonly ProductService _productService;

    public ProductService_Unit()
    {
        _mockProductRepo = new Mock<IProductRepo>();
        _productService = new ProductService(_mockProductRepo.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        // Arrange
        var response = new List<ProductEntity>()
        {
            new ProductEntity {
                Id = 1,
                Name = "Product 1",
                Description = "Description 1",
                Price = 100m,
                CategoryId = 1,
            },
            new ProductEntity {
                Id = 2,
                Name = "Product 2",
                Description = "Description 2",
                Price = 100m,
                CategoryId = 1,
            }
        };
        _mockProductRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(response);

        // Act 
        var result = await _productService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(2, result[1].Id);
        Assert.Equal("Product 1", result[0].Name);
        Assert.Equal("Product 2", result[1].Name);
    }
}
