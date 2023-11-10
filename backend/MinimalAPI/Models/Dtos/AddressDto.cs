using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record AddressDTO(
    string StreetAddress,
    string City,
    string PostalCode
)
{
    public static AddressDTO Create(Address entity) => new(
        entity.StreetAddress,
        entity.City,
        entity.PostalCode
    );
}

public static class AddressDTOExtensions
{
    public static Address ConvertToEntity(this AddressDTO dto) => new()
    {
        StreetAddress = dto.StreetAddress,
        City = dto.City,
        PostalCode = dto.PostalCode
    };
}
