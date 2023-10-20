using WebAPI.Helpers.Repositories;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Helpers.Services;

public class CustomerService
{
    private readonly CustomerRepo _customerRepo;

    public CustomerService(CustomerRepo customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public async Task<CustomerEntity> CreateCustomerAsync(CustomerCreateSchema schema)
    {
        var entity = await _customerRepo.CreateAsync(schema);

        return entity;
    }
}
