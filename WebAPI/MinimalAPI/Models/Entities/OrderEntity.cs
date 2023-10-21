using System.ComponentModel.DataAnnotations.Schema;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Column(TypeName = "money")]
    public required decimal TotalPrice { get; set; }
    public int StatusId { get; set; } = 1;
    public OrderStatusEntity? Status { get; set; }
    public required int? CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }
    public required int AddressId { get; set; }
    public AddressEntity? Address { get; set; }
    public List<OrderItemEntity> Items { get; set; } = new();

    public static implicit operator OrderDto(OrderEntity entity) => OrderDto.Create(entity);
}