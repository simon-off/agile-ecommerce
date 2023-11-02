using System.Linq.Expressions;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface IAddressService
{
    Task<AddressDto?> GetById(int id);
    Task<AddressDto> CreateCustomerAddressAsync(AddressCreateSchema schema, int customerId);
    Task<AddressDto> CreateUserAddressAsync(AddressCreateSchema schema, string userId);
    Task<List<AddressDto>> GetAllAsync(Expression<Func<AddressEntity, bool>> predicate);
    Task<AddressDto> UpdateUserAddressAsync(AddressUpdateSchema schema, string userId);
    Task<bool> IsAddressOwnedByUserAsync(int addressId, string userId);
    Task<bool> DeleteAsync(int addressId);
}
