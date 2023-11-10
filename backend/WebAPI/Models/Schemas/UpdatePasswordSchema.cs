using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Schemas;

public class UpdatePasswordSchema
{
    [Required]
    public string OldPassword { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\d)(?=.*[@$!%*?&])[A-ZÅÄÖa-zåäö\d@$!%*?&]{8,}$")]
    public string NewPassword { get; set; } = null!;
}
