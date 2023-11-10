using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

[PrimaryKey(nameof(OrderId), nameof(SizeId), nameof(ProductId))]
public class OrderItem
{
    public required int OrderId { get; set; }
    public Order? Order { get; set; }

    public required int ProductId { get; set; }
    public Product? Product { get; set; }

    public required int SizeId { get; set; }
    public Size? Size { get; set; }

    public required int Quantity { get; set; }

    public static implicit operator OrderItemDTO(OrderItem entity) => OrderItemDTO.Create(entity);
}
