using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
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

    public async Task<bool> IsAddressOwnedByUserAsync(int addressId, string userId)
    {
        var address = await _addressRepo.GetAsync(x => x.Id == addressId);

        if (address == null)
            return false;

        _addressRepo.StopTrackingEntity(address);
        return address.UserId == userId;
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

    public async Task<AddressDto> CreateUserAddressAsync(AddressCreateSchema schema, string userId)
    {
        var addressEntity = new AddressEntity
        {
            City = schema.City,
            StreetName = schema.StreetAddress,
            PostalCode = schema.PostalCode,
            UserId = userId
        };

        addressEntity = await _addressRepo.CreateAsync(addressEntity);

        return addressEntity;
    }

    public async Task<List<AddressDto>> GetAllAsync(Expression<Func<AddressEntity, bool>> predicate)
    {
        var dtos = new List<AddressDto>();
        var entities = await _addressRepo.GetAllAsync(predicate);

        foreach (var entity in entities)
            dtos.Add(entity);

        return dtos;
    }

    public async Task<AddressDto?> GetById(int id)
    {
        var entity = await _addressRepo.GetAsync(x => x.Id == id);

        if (entity == null)
            return null;

        return entity;
    }

    public async Task<AddressDto> UpdateUserAddressAsync(AddressUpdateSchema schema, string userId)
    {
        var addressEntity = new AddressEntity
        {
            Id = schema.Id,
            City = schema.City,
            StreetName = schema.StreetAddress,
            PostalCode = schema.PostalCode,
            UserId = userId
        };

        addressEntity = await _addressRepo.UpdateAsync(addressEntity);

        return addressEntity;
    }

    public async Task<bool> DeleteAsync(int addressId)
    {
        var entity = await _addressRepo.GetAsync(x => x.Id == addressId);

        if (entity == null)
            return false;

        return await _addressRepo.DeleteAsync(entity);
    }
}
