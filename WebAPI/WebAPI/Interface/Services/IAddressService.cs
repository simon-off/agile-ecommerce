using WebAPI.Models.Dtos;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface IAddressService
{
    Task<AddressDto> CreateCustomerAddressAsync(AddressCreateSchema schema, int customerId);
}
