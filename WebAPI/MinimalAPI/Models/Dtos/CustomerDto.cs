using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record CustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
)
{
    public CustomerDto(CustomerEntity entity) : this(
        FirstName: entity.FirstName,
        LastName: entity.LastName,
        Email: entity.Email,
        PhoneNumber: entity.PhoneNumber
    )
    { }
}