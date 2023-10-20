using System.ComponentModel.DataAnnotations;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Schemas;

public class CustomerCreateSchema
{
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-öA-Ö ])?[a-öA-Ö]*)*$")]
    public required string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-öA-Ö ])?[a-öA-Ö]*)*$")]
    public required string LastName { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(320)]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
    public required string Email { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    [RegularExpression(@"^(\+\d{1,4}\s?)?(\(?\d{1,}\)?[-.\s]?)+\d{1,}$")]
    public required string PhoneNumber { get; set; }

    public static implicit operator CustomerEntity (CustomerCreateSchema schema)
    {
        return new CustomerEntity
        {
            FirstName = schema.FirstName,
            LastName = schema.LastName,
            Email = schema.Email,
            PhoneNumber = schema.PhoneNumber,
        };
    }
}
