using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Helpers.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepo _addressRepo;

    public AddressService(IAddressRepo addressRepo)
    {
        _addressRepo = addressRepo;
    }

    public async Task<AddressDto> CreateCustomerAddressAsync(AddressCreateSchema schema, int customerId)
    {
        var addressEntity = new AddressEntity
        {
            City = schema.City,
            StreetName = schema.StreetAddress,
            PostalCode = schema.PostalCode,
            CustomerId = customerId,
        };

        addressEntity = await _addressRepo.CreateAsync(addressEntity);

        return addressEntity;
    } 
}
