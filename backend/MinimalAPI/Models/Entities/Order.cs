using System.ComponentModel.DataAnnotations.Schema;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Models.Identity;

namespace MinimalAPI.Models.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column(TypeName = "money")]
    public required decimal TotalPrice { get; set; }

    public int StatusId { get; set; } = 1;
    public OrderStatus? Status { get; set; }

    public string? UserId { get; set; }
    public User? User { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }

    public required string StreetAddress { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }

    public List<OrderItem> Items { get; set; } = new();

    public static implicit operator OrderDTO(Order entity) => OrderDTO.Create(entity);
}
