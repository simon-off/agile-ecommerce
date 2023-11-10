using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Data;

public static class Seeder
{
    public static void SeedAll(ModelBuilder builder)
    {
        SeedCategories(builder);
        SeedTags(builder);
        SeedSizes(builder);
        var numberOfProducts = SeedProducts(builder);
        SeedImages(builder, numberOfProducts);
        SeedProductTags(builder, numberOfProducts);
        SeedProductSizes(builder, numberOfProducts);
        SeedOrderStatuses(builder);
    }

    private static void SeedCategories(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Shirts" },
                new Category { Id = 2, Name = "Jackets" },
                new Category { Id = 3, Name = "Pants" },
                new Category { Id = 4, Name = "Footwear" },
                new Category { Id = 5, Name = "Headwear" },
                new Category { Id = 6, Name = "Accessories" },
                new Category { Id = 7, Name = "Dresses" },
                new Category { Id = 8, Name = "Underwear" },
                new Category { Id = 9, Name = "Suits" }
            );
    }

    private static void SeedTags(ModelBuilder builder)
    {
        builder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Featured" },
                new Tag { Id = 2, Name = "Popular" },
                new Tag { Id = 3, Name = "New" },
                new Tag { Id = 4, Name = "Kids" },
                new Tag { Id = 5, Name = "Unisex" },
                new Tag { Id = 6, Name = "Sport" }
            );
    }

    private static void SeedSizes(ModelBuilder builder)
    {
        builder.Entity<Size>().HasData(
                new Size { Id = 1, Name = "XS" },
                new Size { Id = 2, Name = "S" },
                new Size { Id = 3, Name = "M" },
                new Size { Id = 4, Name = "L" },
                new Size { Id = 5, Name = "XL" },
                new Size { Id = 6, Name = "XXL" }
            );
    }

    private static int SeedProducts(ModelBuilder builder)
    {
        var seedData = JArray.Parse(File.ReadAllText(@"Data/product-data.json"));
        var products = new List<Product>();

        foreach (var item in seedData)
        {
            if (item.ToObject<Product>() is Product product)
                products.Add(product);
        }

        builder.Entity<Product>().HasData(products);
        return seedData.Count;
    }

    private static void SeedImages(ModelBuilder builder, int numberOfProducts)
    {
        var productImages = new List<ProductImage>();
        int productImageIndex = 1;

        // adds three identical pictures to all seeded products
        for (int i = 1; i <= numberOfProducts; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                productImages.Add(
                    new ProductImage
                    {
                        Id = productImageIndex,
                        Path = "/images/products/product-template-image.png",
                        ProductId = i
                    }
                );
                productImageIndex++;
            }
        }

        builder.Entity<ProductImage>().HasData(productImages);
    }

    public record ProductTag(int ProductsId, int TagsId);

    private static void SeedProductTags(ModelBuilder builder, int numberOfProducts)
    {
        var productTags = new List<ProductTag>();

        // Makes all seeded products have featured, popular and new tag.
        for (var i = 1; i <= numberOfProducts; i++)
        {
            for (var j = 1; j <= 3; j++)
            {
                productTags.Add(new ProductTag(i, j));
            }
        }

        // Add one product to the rest of the tags
        productTags.Add(new ProductTag(1, 4));
        productTags.Add(new ProductTag(2, 5));
        productTags.Add(new ProductTag(5, 6));

        builder.Entity("ProductTags").HasData(productTags);
    }

    public record ProductSize(int AvailableSizesId, int ProductsId);

    private static void SeedProductSizes(ModelBuilder builder, int numberOfProducts)
    {
        var productSizes = new List<ProductSize>();

        // Make all sizes available to all seeded products
        for (var i = 1; i <= numberOfProducts; i++)
        {
            for (var j = 1; j <= 6; j++)
            {
                productSizes.Add(new ProductSize(j, i));
            }
        }

        builder.Entity("ProductSizes").HasData(productSizes);
    }

    private static void SeedOrderStatuses(ModelBuilder builder)
    {
        builder.Entity<OrderStatus>().HasData(
            new OrderStatus { Id = 1, Name = "Processing" },
            new OrderStatus { Id = 2, Name = "Shipped" },
            new OrderStatus { Id = 3, Name = "Done" }
        );
    }
}
