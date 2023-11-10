using MinimalAPI.Data;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Tests.Helpers;

public class TestSeeder
{
    public static void Seed(DataContext _context)
    {
        var categories = new List<Category>()
        {
            new() { Id = 1, Name = "Pants"},
            new() { Id = 2, Name = "Shirts"},
            new() { Id = 3, Name = "Shoes"}
        };

        var tags = new List<Tag>()
        {
            new() { Id = 1, Name = "Featured" },
            new() { Id = 2, Name = "Popular" },
            new() { Id = 3, Name = "New" },
            new() { Id = 4, Name = "Kids" },
            new() { Id = 5, Name = "Unisex" },
            new() { Id = 6, Name = "Sport" }
        };

        var products = new List<Product>()
        {
            new() {
                Id = 1,
                Name = "Red Pants",
                Description = "A pair of red pants.",
                CategoryId = 1,
                Price = 59.99m
            },
            new() {
                Id = 2,
                Name = "Blue Pants",
                Description = "A pair of blue pants.",
                CategoryId = 1,
                Price = 19.99m
            },
            new() {
                Id = 3,
                Name = "Blue shirt",
                Description = "A blue shirt.",
                CategoryId = 2,
                Price = 69.99m
            },
            new() {
                Id = 4,
                Name = "Red Shirt",
                Description = "A red shirt.",
                CategoryId = 2,
                Price = 59.99m
            }
        };

        // Add Featured, popular and new tags to all products
        foreach (var product in products)
        {
            for (var i = 0; i < 3; i++)
            {
                product.Tags.Add(tags[i]);
            }
        }

        // First item gets kids, second item gets unisex and third item gets sport tag.
        for (var i = 0; i < 3; i++)
        {
            products[i].Tags.Add(tags[i + 3]);
        }

        _context.Tags.AddRange(tags);
        _context.Categories.AddRange(categories);
        _context.Products.AddRange(products);
        _context.SaveChanges();
    }
}
