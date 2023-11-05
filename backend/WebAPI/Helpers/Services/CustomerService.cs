using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Helpers.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepo _customerRepo;

    public CustomerService(ICustomerRepo customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public async Task<CustomerEntity> CreateCustomerAsync(CustomerCreateSchema schema)
    {
        var entity = await _customerRepo.CreateAsync(schema);

        return entity;
    }
}
