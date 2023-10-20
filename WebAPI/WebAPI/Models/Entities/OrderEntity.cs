using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Dtos;

namespace WebAPI.Models.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;
    public int? CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }
    public List<OrderItemEntity> Items { get; set; } = new();

    public static implicit operator OrderDto (OrderEntity entity)
    {
        var dto = new OrderDto
        {
            OrderDate = entity.OrderDate,
            TotalPrice = entity.TotalPrice,
            Status = entity.Status.Name,
            FirstName = entity.Customer?.FirstName,
            LastName = entity.Customer?.LastName,
            Email = entity.Customer?.Email
        };

        foreach (var item in entity.Items) 
            dto.Items.Add(item);

        return dto;
    }
}