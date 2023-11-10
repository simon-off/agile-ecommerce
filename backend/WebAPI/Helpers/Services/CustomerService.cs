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
        var existingCustomer = await _customerRepo.GetAsync(
            x => x.Email == schema.Email
              && x.PhoneNumber == schema.PhoneNumber
              && x.FirstName == schema.FirstName
              && x.LastName == schema.LastName);

        if (existingCustomer != null)
            return existingCustomer;

        var entity = await _customerRepo.CreateAsync(schema);

        return entity;
    }
}
