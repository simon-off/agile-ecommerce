using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Models.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }
    public int StatusId { get; set; }
    public StatusEntity? Status { get; set; }
    public int? CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }
    public List<OrderItemEntity> Items { get; set; } = new();
}

public class OrderItemEntity
{
}

public class CustomerEntity
{
}

public class StatusEntity
{
}