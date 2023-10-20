using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Dtos;

public class OrderDto
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalPrice { get; set; }
    public required string Status { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}
