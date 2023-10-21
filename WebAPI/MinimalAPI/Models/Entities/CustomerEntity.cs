using System.ComponentModel.DataAnnotations.Schema;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public required string FirstName { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public required string LastName { get; set; }
    [Column(TypeName = "nvarchar(320)")]
    public required string Email { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public required string PhoneNumber { get; set; }
    public AddressEntity? Address;
    public List<OrderEntity> Orders = new();

    public static implicit operator CustomerDto(CustomerEntity entity) => CustomerDto.Create(entity);
}