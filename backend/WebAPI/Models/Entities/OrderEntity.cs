using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Dtos;
using WebAPI.Models.Identity;

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
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public List<OrderItemEntity> Items { get; set; } = new();
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
    public string? OrderComment { get; set; }

    public static implicit operator OrderDto(OrderEntity entity)
    {
        var dto = new OrderDto
        {
            OrderDate = entity.OrderDate,
            TotalPrice = entity.TotalPrice,
            Status = entity.Status.Name,
            FirstName = entity.Customer?.FirstName ?? entity.User?.FirstName,
            LastName = entity.Customer?.LastName ?? entity.User?.LastName,
            Email = entity.Customer?.Email ?? entity.User?.Email,
            StreetName = entity.Address.StreetName,
            City = entity.Address.City,
            PostalCode = entity.Address.PostalCode,
            OrderComment = entity.OrderComment
        };

        foreach (var item in entity.Items)
            dto.Items.Add(item);

        return dto;
    }
}