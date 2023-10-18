namespace MinimalAPI.Models.Entities;

public class ProductImageEntity
{
    public int Id { get; set; }
    public required string Path { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
