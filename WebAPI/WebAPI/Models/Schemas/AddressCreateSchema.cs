using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Schemas;

public class AddressCreateSchema
{
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public required string StreetAddress { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public required string City { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public required string PostalCode { get; set; }
}
