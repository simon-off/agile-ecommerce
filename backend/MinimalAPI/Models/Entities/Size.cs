namespace MinimalAPI.Models.Entities;

public class Size
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Product> Products { get; set; } = new();
}
