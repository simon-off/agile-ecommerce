namespace WebAPI.Models.Dtos;

public class AddressDto
{
    public int Id { get; set; }
    public required string StreetName { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
}
