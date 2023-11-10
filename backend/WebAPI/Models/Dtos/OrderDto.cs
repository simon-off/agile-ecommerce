namespace WebAPI.Models.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItemDto> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
    public required string Status { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string StreetName { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public string? OrderComment { get; set; }
}
