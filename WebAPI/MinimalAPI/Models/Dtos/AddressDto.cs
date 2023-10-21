using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record AddressDto(
    string StreetAddress,
    string City,
    string PostalCode
)
{
    public static AddressDto Create(AddressEntity entity) => new(
        entity.StreetAddress,
        entity.City,
        entity.PostalCode
    );
}

public static class AddressExtensions
{
    public static AddressEntity CreateEntity(this AddressDto dto) => new()
    {
        StreetAddress = dto.StreetAddress,
        City = dto.City,
        PostalCode = dto.PostalCode
    };
}