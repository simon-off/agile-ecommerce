using WebAPI.Data;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Models.Schemas;
using WebAPITest.Helpers;

namespace WebAPITest.ServiceTests;

[Collection("Database collection")]
public class CustomerServiceTest
{
    private readonly DataContext _context;
    private readonly CustomerRepo _customerRepo;
    private readonly CustomerService _customerService;

    public CustomerServiceTest(DatabaseFixture fixture)
    {
        _context = fixture.CreateContext();
        _customerRepo = new CustomerRepo(_context);
        _customerService = new CustomerService(_customerRepo);
    }

    [Fact]
    public async Task CreateCustomerAsync_CreateCustomer()
    {
        // Arrange fake user data
        var customerSchema = new CustomerCreateSchema
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@sdomain.com",
            PhoneNumber = "1745885599",
        };

        // Act
        await _customerService.CreateCustomerAsync(customerSchema);

        var actualUser = await _customerRepo.GetAsync(x => x.FirstName == customerSchema.FirstName && x.LastName == customerSchema.LastName);

        // Assert
        Assert.NotNull(actualUser);
        Assert.Equal(customerSchema.FirstName, actualUser.FirstName);
        Assert.Equal(customerSchema.LastName, actualUser.LastName);
        Assert.Equal(customerSchema.Email, actualUser.Email);
        Assert.Equal(customerSchema.PhoneNumber, actualUser.PhoneNumber);
    }
}
