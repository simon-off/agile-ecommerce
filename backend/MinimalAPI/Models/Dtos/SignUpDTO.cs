using MinimalAPI.Models.Identity;

namespace MinimalAPI.Models.Dtos;

public record SignUpDTO(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber
);

public static class SignUpDTOExtensions
{
    public static User ConvertToEntity(this SignUpDTO dto) => new()
    {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        UserName = dto.Email,
        PhoneNumber = dto.PhoneNumber
    };
}
