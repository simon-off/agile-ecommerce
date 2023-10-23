using Castle.Core.Resource;
using Moq;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPITest.UnitTests.ServiceTests;

public class AddressService_Unit
{
    private readonly Mock<IAddressRepo> _mockAddressRepo;
    private readonly AddressService _addressService;

    public AddressService_Unit()
    {
        _mockAddressRepo = new Mock<IAddressRepo>();
        _addressService = new AddressService(_mockAddressRepo.Object);
    }

    [Fact]
    public async Task CreateCustomerAddress_ShouldReturnCreatedAddress()
    {
        // Arrange
        var customerId = 1;
        var addressSchema = new AddressCreateSchema
        {
            StreetAddress = "Test Street 1",
            City = "Alingsås",
            PostalCode = "441 41"
        };
        var response = new AddressEntity
        {
            Id = 1,
            City = addressSchema.City,
            StreetName = addressSchema.StreetAddress,
            PostalCode = addressSchema.PostalCode,
            CustomerId = customerId,
        };

        _mockAddressRepo.Setup(x => x.CreateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(response);

        //Act
        var result = await _addressService.CreateCustomerAddressAsync(addressSchema, customerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(response.StreetName, result.StreetName);
        Assert.Equal(response.City, result.City);
        Assert.Equal(response.PostalCode, result.PostalCode);
    }
}
