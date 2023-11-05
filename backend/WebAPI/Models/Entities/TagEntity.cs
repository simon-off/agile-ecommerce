using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Dtos;

namespace WebAPI.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public required string Name { get; set; }
    public List<ProductEntity> Products { get; set; } = new();

    public static implicit operator TagDto(TagEntity entity)
    {
        return new TagDto { Name = entity.Name, Id = entity.Id };
    }
}