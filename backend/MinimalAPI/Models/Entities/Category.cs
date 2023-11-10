namespace MinimalAPI.Models.Entities;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Product> Products { get; set; } = new();

    public static implicit operator string(Category entity) => entity.Name;
}
