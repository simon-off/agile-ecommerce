

using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Models.Schemas;
using WebAPITest.Helpers;

namespace WebAPITest.ServiceTests;

[Collection("Database collection")]
public class AddressServiceTests
{
    private readonly DatabaseFixture _fixture;
    private readonly DataContext _context;
    private readonly CustomerRepo _customerRepo;
    private readonly CustomerService _customerService;
    private readonly AddressRepo _addressRepo;
    private readonly AddressService _addressService;
    public AddressServiceTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.CreateContext();
        _customerRepo = new CustomerRepo(_context);
        _customerService = new CustomerService(_customerRepo);
        _addressRepo = new AddressRepo(_context);
        _addressService = new AddressService(_addressRepo);
    }

    [Fact]
    public async Task CreateCustomerAddress_ShouldCreateAddress()
    {
        // Arrange fake user data
        var customerSchema = new CustomerCreateSchema
        {
            FirstName = "Address",
            LastName = "Customer",
            Email = "address.customer@sdomain.com",
            PhoneNumber = "1745885599",
        };



        var customerEntity = await _customerService.CreateCustomerAsync(customerSchema);
        var addressSchema = new AddressCreateSchema
        {
            StreetAddress = "Kungsgatan 12",
            City = "Gothenburg",
            PostalCode = "12345",
        };

        // Act
        await _addressService.CreateCustomerAddressAsync(addressSchema, customerEntity.Id);
        var actualAddress = await _addressRepo.GetAsync(x => x.StreetName == addressSchema.StreetAddress);

        // Assert
        Assert.NotNull(actualAddress);
        Assert.Equal(addressSchema.StreetAddress, actualAddress.StreetName);
        Assert.Equal(addressSchema.City, actualAddress.City);
        Assert.Equal(addressSchema.PostalCode, actualAddress.PostalCode);
    }
}
