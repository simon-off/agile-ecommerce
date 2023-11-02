using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPITest.Helpers;

public class SeederTestDatabase
{
    private readonly DataContext _context;

    public SeederTestDatabase(DataContext context)
    {
        _context = context;
    }

    public void SeedProductsMockDatabase()
    {
        var categories = new List<CategoryEntity>()
        {
            new CategoryEntity { Id = 1, Name = "Pants"},
            new CategoryEntity { Id = 2, Name = "Shirts"},
            new CategoryEntity { Id = 3, Name = "Shoes"}
        };

        var tags = new List<TagEntity>()
        {
            new TagEntity { Id = 1, Name = "Featured" },
            new TagEntity { Id = 2, Name = "Popular" },
            new TagEntity { Id = 3, Name = "New" },
            new TagEntity { Id = 4, Name = "Kids" },
            new TagEntity { Id = 5, Name = "Unisex" },
            new TagEntity { Id = 6, Name = "Sport" }
        };

        var products = new List<ProductEntity>()
        {
            new ProductEntity
            {
                Id = 1,
                Name = "Red Pants",
                Description = "A pair of red pants.",
                CategoryId = 1,
                Price = 59.99m
            },
            new ProductEntity
            {
                Id = 2,
                Name = "Blue Pants",
                Description = "A pair of blue pants.",
                CategoryId = 1,
                Price = 19.99m
            },
            new ProductEntity
            {
                Id = 3,
                Name = "Blue shirt",
                Description = "A blue shirt.",
                CategoryId = 2,
                Price = 69.99m
            },
            new ProductEntity
            {
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
