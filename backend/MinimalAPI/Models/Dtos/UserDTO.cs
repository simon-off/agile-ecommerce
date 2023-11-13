using MinimalAPI.Models.Identity;

namespace MinimalAPI.Models.Dtos;

public record UserDTO(
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber
)
{
    public static UserDTO Create(User entity) => new(
        entity.FirstName,
        entity.LastName,
        entity.Email,
        entity.PhoneNumber
    );
}