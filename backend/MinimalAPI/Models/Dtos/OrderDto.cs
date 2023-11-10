using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record OrderDTO(
    int Id,
    DateTime CreatedAt,
    decimal TotalPrice,
    string? Status,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string StreetAddress,
    string PostalCode,
    string City,
    List<OrderItemDTO> Items
)
{
    public static OrderDTO Create(Order entity) => new(
        entity.Id,
        entity.CreatedAt,
        entity.TotalPrice,
        entity.Status?.Name,
        entity.FirstName,
        entity.LastName,
        entity.Email,
        entity.PhoneNumber,
        entity.StreetAddress,
        entity.PostalCode,
        entity.City,
        entity.Items.Select(OrderItemDTO.Create).ToList()
    );
}
