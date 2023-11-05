using Moq;
using System.Runtime.CompilerServices;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPITest.UnitTests.ServiceTests;

public class CustomerService_Unit
{
    private readonly Mock<ICustomerRepo> _mockCustomerRepo;
    private readonly CustomerService _customerService;

    public CustomerService_Unit()
    {
        _mockCustomerRepo = new Mock<ICustomerRepo>();
        _customerService = new CustomerService(_mockCustomerRepo.Object);
    }

    [Fact]
    public async Task CreateCustomerAsync_ShouldReturnCreatedCustomer()
    {
        // Arrange
        var schema = new CustomerCreateSchema
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            PhoneNumber = "0704755768"
        };
        var response = new CustomerEntity
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            PhoneNumber = "0704755768",
            Addresses = new List<AddressEntity>(),
            Orders = new List<OrderEntity>()
        };
        _mockCustomerRepo.Setup(x => x.CreateAsync(It.IsAny<CustomerEntity>())).ReturnsAsync(response);

        // Act
        var result = await _customerService.CreateCustomerAsync(schema);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(response.Id, result.Id);
        Assert.Equal(response.FirstName, result.FirstName);
        Assert.Equal(response.LastName, result.LastName);
        Assert.Equal(response.Email, result.Email);
        Assert.Equal(response.PhoneNumber, result.PhoneNumber);
    }
}
