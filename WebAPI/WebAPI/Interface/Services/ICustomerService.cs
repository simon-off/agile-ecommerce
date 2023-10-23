using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface ICustomerService
{
    Task<CustomerEntity> CreateCustomerAsync(CustomerCreateSchema schema);
}
