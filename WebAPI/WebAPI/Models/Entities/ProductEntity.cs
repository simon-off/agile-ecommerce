using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Dtos;

namespace WebAPI.Models.Entities;

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

    public static implicit operator ProductDto(ProductEntity entity)
    {
        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Category = entity.Category?.Name,
            Tags = entity.Tags.Select(x => x.Name).ToList(),
            ImagePaths = entity.Images.Select(x => x.Path).ToList(),
            AvailableSizes = entity.AvailableSizes.Select(x => x.Name).ToList(),
        };
    }
}
