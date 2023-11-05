using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shirts" },
                    { 2, "Jackets" },
                    { 3, "Pants" },
                    { 4, "Footwear" },
                    { 5, "Headwear" },
                    { 6, "Accessories" },
                    { 7, "Dresses" },
                    { 8, "Underwear" },
                    { 9, "Suits" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "XS" },
                    { 2, "S" },
                    { 3, "M" },
                    { 4, "L" },
                    { 5, "XL" },
                    { 6, "XXL" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Featured" },
                    { 2, "Popular" },
                    { 3, "New" },
                    { 4, "Kids" },
                    { 5, "Unisex" },
                    { 6, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Stay warm and stylish this winter with our cozy knit sweater. It's perfect for chilly days and features a classic design that goes well with any outfit.", "Cozy Winter Sweater", 59.99m },
                    { 2, 3, "A wardrobe essential! Our classic denim jeans offer a timeless look and a comfortable fit. Whether you're dressing up or going casual, these jeans have you covered.", "Classic Denim Jeans", 39.99m },
                    { 3, 7, "Dazzle at your next special occasion with our elegant evening dress. This gown features intricate lace details and a flattering silhouette that's sure to turn heads.", "Elegant Evening Dress", 129.99m },
                    { 4, 1, "Spend your weekends in comfort and style with our casual t-shirt. It's made from soft, breathable fabric and comes in various colors to suit your mood.", "Casual Weekend T-Shirt", 19.99m },
                    { 5, 3, "Get active in our sporty jogging pants. These pants are designed for maximum comfort during workouts and leisure activities. Stay on the move with confidence.", "Sporty Jogging Pants", 29.99m },
                    { 6, 2, "Achieve a timeless, edgy look with our chic leather jacket. Crafted from high-quality leather, it's a versatile piece that adds an element of sophistication to any outfit.", "Chic Leather Jacket", 79.99m },
                    { 7, 3, "Ready for some fun in the sun? Our summer beach shorts are perfect for beach days and pool parties. They come in vibrant colors and are quick-drying for your comfort.", "Summer Beach Shorts", 24.99m },
                    { 8, 9, "Make a professional statement with our formal business suit. It's tailored to perfection, exuding confidence and style. Ideal for meetings and special events.", "Formal Business Suit", 199.99m }
                });

            migrationBuilder.InsertData(
                table: "ProductEntitySizeEntity",
                columns: new[] { "AvailableSizesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 6 },
                    { 6, 7 },
                    { 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "ProductEntityTagEntity",
                columns: new[] { "ProductsId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 6 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Path", "ProductId" },
                values: new object[,]
                {
                    { 1, "/images/products/product-template-image.png", 1 },
                    { 2, "/images/products/product-template-image.png", 1 },
                    { 3, "/images/products/product-template-image.png", 1 },
                    { 4, "/images/products/product-template-image.png", 2 },
                    { 5, "/images/products/product-template-image.png", 2 },
                    { 6, "/images/products/product-template-image.png", 2 },
                    { 7, "/images/products/product-template-image.png", 3 },
                    { 8, "/images/products/product-template-image.png", 3 },
                    { 9, "/images/products/product-template-image.png", 3 },
                    { 10, "/images/products/product-template-image.png", 4 },
                    { 11, "/images/products/product-template-image.png", 4 },
                    { 12, "/images/products/product-template-image.png", 4 },
                    { 13, "/images/products/product-template-image.png", 5 },
                    { 14, "/images/products/product-template-image.png", 5 },
                    { 15, "/images/products/product-template-image.png", 5 },
                    { 16, "/images/products/product-template-image.png", 6 },
                    { 17, "/images/products/product-template-image.png", 6 },
                    { 18, "/images/products/product-template-image.png", 6 },
                    { 19, "/images/products/product-template-image.png", 7 },
                    { 20, "/images/products/product-template-image.png", 7 },
                    { 21, "/images/products/product-template-image.png", 7 },
                    { 22, "/images/products/product-template-image.png", 8 },
                    { 23, "/images/products/product-template-image.png", 8 },
                    { 24, "/images/products/product-template-image.png", 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
