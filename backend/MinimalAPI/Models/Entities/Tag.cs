namespace MinimalAPI.Models.Entities;

public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Product> Products { get; set; } = new();

    public static implicit operator string(Tag entity) => entity.Name;
}
