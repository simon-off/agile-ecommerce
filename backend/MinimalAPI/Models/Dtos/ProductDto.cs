using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Dtos;

public record ProductDTO(
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
    public static ProductDTO Create(Product entity) => new(
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
