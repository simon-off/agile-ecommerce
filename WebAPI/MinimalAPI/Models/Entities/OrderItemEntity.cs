using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

[PrimaryKey(nameof(OrderId), nameof(SizeId), nameof(ProductId))]
public class OrderItemEntity
{
    public required int OrderId { get; set; }
    public OrderEntity? Order { get; set; }
    public required int ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    public required int SizeId { get; set; }
    public SizeEntity? Size { get; set; }
    public required int Quantity { get; set; }

    public static implicit operator OrderItemDto(OrderItemEntity entity) => OrderItemDto.Create(entity);
}
