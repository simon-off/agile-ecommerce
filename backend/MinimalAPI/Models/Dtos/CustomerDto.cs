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

public static class CustomerExtensions
{
    public static CustomerEntity CreateEntity(this CustomerDto dto) => new()
    {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber
    };
}