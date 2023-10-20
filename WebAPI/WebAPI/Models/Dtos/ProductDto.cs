namespace WebAPI.Models.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Tags { get; set; } = new();
    public string Category { get; set; } = null!;
    public List<string> ImagePaths { get; set; } = new();
    public List<string> AvailableSizes { get; set; } = new();
}
