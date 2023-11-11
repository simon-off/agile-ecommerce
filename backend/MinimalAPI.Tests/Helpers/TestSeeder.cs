using MinimalAPI.Data;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Tests.Helpers;

public class TestSeeder
{
    public static void Seed(DataContext _context)
    {
        var sizes = new List<Size>()
        {
            new() { Id = 1, Name = "S" },
            new() { Id = 2, Name = "M" },
            new() { Id = 3, Name = "L" }
        };

        var categories = new List<Category>()
        {
            new() { Id = 1, Name = "Pants"},
            new() { Id = 2, Name = "Shirts"},
            new() { Id = 3, Name = "Shoes"}
        };

        var tags = new List<Tag>()
        {
            new() { Id = 1, Name = "Popular" },
            new() { Id = 2, Name = "Unisex" },
            new() { Id = 3, Name = "Sport" }
        };

        var products = new List<Product>()
        {
            new() {
                Id = 1,
                Name = "Red Pants",
                Description = "A pair of red pants.",
                CategoryId = 1,
                Price = 59.99m,
                AvailableSizes = sizes
            },
            new() {
                Id = 2,
                Name = "Blue Pants",
                Description = "A pair of blue pants.",
                CategoryId = 1,
                Price = 19.99m,
                AvailableSizes = sizes
            },
            new() {
                Id = 3,
                Name = "Blue shirt",
                Description = "A blue shirt.",
                CategoryId = 2,
                Price = 69.99m,
                AvailableSizes = sizes
            }
        };

        // First 2 items gets "Popular"
        // Second item gets "unisex"
        // Third item gets "sport"
        products[0].Tags.Add(tags[0]);
        products[1].Tags.Add(tags[0]);
        products[1].Tags.Add(tags[1]);
        products[2].Tags.Add(tags[2]);

        _context.Sizes.AddRange(sizes);
        _context.Tags.AddRange(tags);
        _context.Categories.AddRange(categories);
        _context.Products.AddRange(products);
        _context.SaveChanges();
    }
}
