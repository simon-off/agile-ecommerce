using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record AddressDto(
    string StreetAddress,
    string City,
    string PostalCode
)
{
    public AddressDto(AddressEntity entity) : this(
        entity.StreetAddress,
        entity.City,
        entity.PostalCode
    )
    { }
}