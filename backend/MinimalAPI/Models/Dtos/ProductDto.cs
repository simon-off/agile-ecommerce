using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string? Category,
    List<string> Tags,
    List<string> ImagePaths,
    List<string> AvailableSizes
)
{
    public static ProductDto Create(ProductEntity entity) => new(
        entity.Id,
        entity.Name,
        entity.Description,
        entity.Price,
        entity.Category?.Name,
        entity.Tags.Select(x => x.Name).ToList(),
        entity.Images.Select(x => x.Path).ToList(),
        entity.AvailableSizes.Select(x => x.Name).ToList()
        );
}
