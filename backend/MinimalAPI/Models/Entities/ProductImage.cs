namespace MinimalAPI.Models.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public required string Path { get; set; }

    public required int ProductId { get; set; }
    public Product? Product { get; set; }
}
