using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record CustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
)
{
    public static CustomerDto Create(CustomerEntity entity) => new(
        entity.FirstName,
        entity.LastName,
        entity.Email,
        entity.PhoneNumber
    );
}