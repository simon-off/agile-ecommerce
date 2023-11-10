using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

public class Address
{
    public int Id { get; set; }
    public required string StreetAddress { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }

    public static implicit operator AddressDTO(Address entity) => AddressDTO.Create(entity);
}
