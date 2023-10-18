using System.ComponentModel.DataAnnotations.Schema;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public List<TagEntity> Tags { get; set; } = new();
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public List<ProductImageEntity> Images { get; set; } = new();
    public List<SizeEntity> AvailableSizes { get; set; } = new();

    public static implicit operator ProductDto(ProductEntity entity) => new(entity);
}
