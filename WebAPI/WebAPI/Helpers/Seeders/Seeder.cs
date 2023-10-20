﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebAPI.Models.Entities;
using static WebAPI.Helpers.Seeders.Seeder;

namespace WebAPI.Helpers.Seeders;

public static class Seeder
{
    public static void SeedAll(ModelBuilder builder)
    {
        SeedCategories(builder);
        SeedTags(builder);
        SeedSizes(builder);
        SeedProducts(builder);
        SeedImages(builder);
        SeedProductTags(builder);
        SeedProductSizes(builder);
        SeedStatuses(builder);
    }

    private static void SeedCategories(ModelBuilder builder)
    {
        builder.Entity<CategoryEntity>().HasData(
             new CategoryEntity { Id = 1, Name = "Shirts" },
             new CategoryEntity { Id = 2, Name = "Jackets" },
             new CategoryEntity { Id = 3, Name = "Pants" },
             new CategoryEntity { Id = 4, Name = "Footwear" },
             new CategoryEntity { Id = 5, Name = "Headwear" },
             new CategoryEntity { Id = 6, Name = "Accessories" },
             new CategoryEntity { Id = 7, Name = "Dresses" },
             new CategoryEntity { Id = 8, Name = "Underwear" },
             new CategoryEntity { Id = 9, Name = "Suits" }
        );
    }

    private static void SeedTags(ModelBuilder builder)
    {
        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, Name = "Featured" },
            new TagEntity { Id = 2, Name = "Popular" },
            new TagEntity { Id = 3, Name = "New" },
            new TagEntity { Id = 4, Name = "Kids" },
            new TagEntity { Id = 5, Name = "Unisex" },
            new TagEntity { Id = 6, Name = "Sport" }
        );
    }

    private static void SeedSizes(ModelBuilder builder)
    {
        builder.Entity<SizeEntity>().HasData(
            new SizeEntity { Id = 1, Name = "XS" },
            new SizeEntity { Id = 2, Name = "S" },
            new SizeEntity { Id = 3, Name = "M" },
            new SizeEntity { Id = 4, Name = "L" },
            new SizeEntity { Id = 5, Name = "XL" },
            new SizeEntity { Id = 6, Name = "XXL" }
        );
    }

    private static void SeedProducts(ModelBuilder builder)
    {
        var seedData = JArray.Parse(File.ReadAllText(@"Helpers/Seeders/product-data.json"));
        var products = new List<ProductEntity>();

        foreach (var item in seedData)
        {
            var product = item.ToObject<ProductEntity>();

            if (product != null)
                products.Add(product);
        }

        builder.Entity<ProductEntity>().HasData(products);
    }

    private static void SeedImages(ModelBuilder builder)
    {
        var productImages = new List<ProductImageEntity>();
        int productImageIndex = 1;

        // adds three identical pictures to all seeded products
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                productImages.Add(new ProductImageEntity { Id = productImageIndex, Path = "/images/products/product-template-image.png", ProductId = i });
                productImageIndex++;
            }
        }

        builder.Entity<ProductImageEntity>().HasData(productImages);
    }

    public record ProductTag(int ProductsId, int TagsId);

    private static void SeedProductTags(ModelBuilder builder)
    {
        var productTags = new List<ProductTag>();

        // Makes all seeded products have featured, popular and new tag.
        for (var i = 1; i <= 8; i++)
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

        builder.Entity("ProductEntityTagEntity").HasData(productTags);
    }

    public record ProductSize(int AvailableSizesId, int ProductsId);

    private static void SeedProductSizes(ModelBuilder builder)
    {
        var productSizes = new List<ProductSize>();

        // Make all sizes available to all seeded products
        for (var i = 1; i <= 8; i++)
        {
            for (var j = 1; j <= 6; j++)
            {
                productSizes.Add(new ProductSize(j, i));
            }
        }

        builder.Entity("ProductEntitySizeEntity").HasData(productSizes);
    }

    private static void SeedStatuses(ModelBuilder builder)
    {
        builder.Entity<StatusEntity>().HasData(
            new StatusEntity { Id = 1, Name = "Processing" },
            new StatusEntity { Id = 2, Name = "Shipped" },
            new StatusEntity { Id = 3, Name = "Done" }
        );
    }
}
