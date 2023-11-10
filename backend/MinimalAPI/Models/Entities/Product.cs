using System.ComponentModel.DataAnnotations.Schema;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    [Column(TypeName = "money")]
    public required decimal Price { get; set; }

    public required int CategoryId { get; set; }
    public Category? Category { get; set; }

    public List<Tag> Tags { get; set; } = new();
    public List<ProductImage> Images { get; set; } = new();
    public List<Size> AvailableSizes { get; set; } = new();

    public static implicit operator ProductDTO(Product entity) => ProductDTO.Create(entity);
}
