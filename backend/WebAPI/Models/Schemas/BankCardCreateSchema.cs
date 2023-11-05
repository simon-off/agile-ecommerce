using System.ComponentModel.DataAnnotations;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Schemas;

public class BankCardCreateSchema
{
    [Required]
    [MaxLength(16)]
    [MinLength(16)]
    [RegularExpression(@"^\d{16}$")]
    public required string CreditCardNumber { get; set; }

    [Required]
    [RegularExpression(@"^\d{3}$")]
    public int CVC { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(255)]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-öA-Ö ])?[a-öA-Ö]*)*$")]
    public required string CardholderName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-öA-Ö ])?[a-öA-Ö]*)*$")]
    public required string CardIssuer { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(5)]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/[0-9]{2}$")]
    public required string ExpirationDate { get; set; }

    public static implicit operator BankCardEntity(BankCardCreateSchema schema)
    {
        return new BankCardEntity
        {
            CreditCardNumber = schema.CreditCardNumber,
            CVC = schema.CVC,
            CardholderName = schema.CardholderName,
            ExpirationDate = schema.ExpirationDate,
            CardIssuer = schema.CardIssuer,
        };
    }
}
