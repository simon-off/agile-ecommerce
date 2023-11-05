using System.ComponentModel.DataAnnotations.Schema;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

public class AddressEntity
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public required string StreetAddress { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public required string City { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public required string PostalCode { get; set; }

    public static implicit operator AddressDto(AddressEntity entity) => AddressDto.Create(entity);
}