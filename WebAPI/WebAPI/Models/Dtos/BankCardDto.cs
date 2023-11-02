namespace WebAPI.Models.Dtos;

public class BankCardDto
{
    public int Id { get; set; }
    public required string CreditCardNumber { get; set; }
    public int CVC { get; set; }
    public required string CardholderName { get; set; }
    public required string CardIssuer { get; set; }
    public required string ExpirationDate { get; set; }
}
