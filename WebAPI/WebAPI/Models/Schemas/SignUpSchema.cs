using System.ComponentModel.DataAnnotations;
using WebAPI.Models.Dtos;
using WebAPI.Models.Identity;

namespace WebAPI.Models.Schemas;

public class SignUpSchema
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    [Required]
    [MinLength(6)]
    [MaxLength(320)]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
    public string Password { get; set; } = null!;

    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    [RegularExpression(@"^(\+\d{1,4}\s?)?(\(?\d{1,}\)?[-.\s]?)+\d{1,}$")]
    public required string PhoneNumber { get; set; }

    public static implicit operator AppUser(SignUpSchema schema)
    {
        return new AppUser
        {
            UserName = schema.Email.ToLower(),
            FirstName = schema.FirstName,
            LastName = schema.LastName,
            Email = schema.Email.ToLower(),
            PhoneNumber = schema.PhoneNumber
        };
    }
}
