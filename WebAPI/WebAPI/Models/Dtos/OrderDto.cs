namespace WebAPI.Models.Dtos;

public class OrderDto
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalPrice { get; set; }
    public required string Status { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
    public required string StreetName { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public string? OrderComment { get; set; }
}
