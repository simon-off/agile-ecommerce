using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderCreateDTO(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string StreetAddress,
    string PostalCode,
    string City,
    List<OrderItemDTO> Items
);

public static class OrderCreateDTOExtensions
{
    public static Order ConvertToEntity(this OrderCreateDTO dto, decimal totalPrice) => new()
    {
        TotalPrice = totalPrice,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber,
        StreetAddress = dto.StreetAddress,
        PostalCode = dto.PostalCode,
        City = dto.City,
    };
}
