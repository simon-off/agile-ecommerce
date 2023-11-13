using MinimalAPI.Models.Identity;

namespace MinimalAPI.Models.Entities;

public class PaymentCard
{
    public int Id { get; set; }
    public required string CardNumber { get; set; }
    public required string CardHolderName { get; set; }
    public required DateOnly ExpirationDate { get; set; }
    public required string CVV { get; set; }

    public required int UserId { get; set; }
    public User? User { get; set; }
}
