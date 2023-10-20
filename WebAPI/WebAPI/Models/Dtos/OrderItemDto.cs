using WebAPI.Models.Entities;

namespace WebAPI.Models.Dtos;

public class OrderItemDto
{
    public ProductDto Product { get; set; } = null!;
    public required string Size { get; set; }
    public int Quantity { get; set; }
}
