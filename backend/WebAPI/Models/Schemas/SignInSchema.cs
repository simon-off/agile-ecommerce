using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Schemas;

public class SignInSchema
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
