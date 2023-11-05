using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Entities;

public class SizeEntity
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(5)")]
    public required string Name { get; set; }
    public List<ProductEntity> Products { get; set; } = new();
}
