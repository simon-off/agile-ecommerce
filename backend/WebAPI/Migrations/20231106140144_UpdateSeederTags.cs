using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeederTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 3, 3 });

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
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.InsertData(
                table: "ProductEntityTagEntity",
                columns: new[] { "ProductsId", "TagsId" },
                values: new object[,]
                {
                    { 2, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 6, 6 },
                    { 7, 6 },
                    { 21, 2 },
                    { 21, 3 },
                    { 22, 2 },
                    { 22, 3 },
                    { 23, 2 },
                    { 23, 3 },
                    { 24, 2 },
                    { 24, 3 },
                    { 25, 2 },
                    { 25, 3 },
                    { 26, 3 },
                    { 27, 3 },
                    { 28, 3 },
                    { 29, 3 },
                    { 30, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 31, 1, "Add a pop of pattern to your wardrobe with our patterned polo shirt. It's a versatile choice for a stylish and comfortable casual look.", "Patterned Polo Shirt", 34.99m },
                    { 32, 2, "Stay protected from the wind in our lightweight windbreaker. It's the perfect companion for outdoor activities and unpredictable weather.", "Lightweight Windbreaker", 49.99m },
                    { 33, 3, "Get a sleek and modern look with our slim-fit jeans. These jeans are designed for a trendy style and comfortable fit.", "Slim-Fit Jeans", 44.99m },
                    { 34, 4, "Step up your footwear game with our classic Oxford shoes. These timeless shoes are suitable for formal events and office wear.", "Classic Oxford Shoes", 79.99m },
                    { 35, 5, "Stay shaded and stylish with our wide-brim sun hat. It's the perfect accessory for sunny days and outdoor adventures.", "Wide-Brim Sun Hat", 19.99m },
                    { 36, 6, "Complete your outfit with our leather belt. It's a classic accessory that adds a touch of sophistication to your look.", "Leather Belt", 24.99m },
                    { 37, 7, "Channel retro vibes with our vintage floral dress. This dress features a timeless floral pattern and is perfect for a classic look.", "Vintage Floral Dress", 54.99m },
                    { 38, 8, "Experience ultimate comfort with our boxer briefs. Made from soft, breathable fabric, they're perfect for everyday wear.", "Comfortable Boxer Briefs", 14.99m },
                    { 39, 9, "Make a bold statement with our modern tuxedo. It's tailored to perfection and is ideal for formal events and special occasions.", "Modern Tuxedo", 299.99m },
                    { 40, 1, "Stay cozy and stylish with our striped V-neck sweater. It's a classic choice for a casual yet sophisticated look.", "Striped V-Neck Sweater", 39.99m }
                });

            migrationBuilder.InsertData(
                table: "ProductEntitySizeEntity",
                columns: new[] { "AvailableSizesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 31 },
                    { 1, 32 },
                    { 1, 33 },
                    { 1, 34 },
                    { 1, 35 },
                    { 1, 36 },
                    { 1, 37 },
                    { 1, 38 },
                    { 1, 39 },
                    { 1, 40 },
                    { 2, 31 },
                    { 2, 32 },
                    { 2, 33 },
                    { 2, 34 },
                    { 2, 35 },
                    { 2, 36 },
                    { 2, 37 },
                    { 2, 38 },
                    { 2, 39 },
                    { 2, 40 },
                    { 3, 31 },
                    { 3, 32 },
                    { 3, 33 },
                    { 3, 34 },
                    { 3, 35 },
                    { 3, 36 },
                    { 3, 37 },
                    { 3, 38 },
                    { 3, 39 },
                    { 3, 40 },
                    { 4, 31 },
                    { 4, 32 },
                    { 4, 33 },
                    { 4, 34 },
                    { 4, 35 },
                    { 4, 36 },
                    { 4, 37 },
                    { 4, 38 },
                    { 4, 39 },
                    { 4, 40 },
                    { 5, 31 },
                    { 5, 32 },
                    { 5, 33 },
                    { 5, 34 },
                    { 5, 35 },
                    { 5, 36 },
                    { 5, 37 },
                    { 5, 38 },
                    { 5, 39 },
                    { 5, 40 },
                    { 6, 31 },
                    { 6, 32 },
                    { 6, 33 },
                    { 6, 34 },
                    { 6, 35 },
                    { 6, 36 },
                    { 6, 37 },
                    { 6, 38 },
                    { 6, 39 },
                    { 6, 40 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Path", "ProductId" },
                values: new object[,]
                {
                    { 91, "/images/products/product-template-image.png", 31 },
                    { 92, "/images/products/product-template-image.png", 31 },
                    { 93, "/images/products/product-template-image.png", 31 },
                    { 94, "/images/products/product-template-image.png", 32 },
                    { 95, "/images/products/product-template-image.png", 32 },
                    { 96, "/images/products/product-template-image.png", 32 },
                    { 97, "/images/products/product-template-image.png", 33 },
                    { 98, "/images/products/product-template-image.png", 33 },
                    { 99, "/images/products/product-template-image.png", 33 },
                    { 100, "/images/products/product-template-image.png", 34 },
                    { 101, "/images/products/product-template-image.png", 34 },
                    { 102, "/images/products/product-template-image.png", 34 },
                    { 103, "/images/products/product-template-image.png", 35 },
                    { 104, "/images/products/product-template-image.png", 35 },
                    { 105, "/images/products/product-template-image.png", 35 },
                    { 106, "/images/products/product-template-image.png", 36 },
                    { 107, "/images/products/product-template-image.png", 36 },
                    { 108, "/images/products/product-template-image.png", 36 },
                    { 109, "/images/products/product-template-image.png", 37 },
                    { 110, "/images/products/product-template-image.png", 37 },
                    { 111, "/images/products/product-template-image.png", 37 },
                    { 112, "/images/products/product-template-image.png", 38 },
                    { 113, "/images/products/product-template-image.png", 38 },
                    { 114, "/images/products/product-template-image.png", 38 },
                    { 115, "/images/products/product-template-image.png", 39 },
                    { 116, "/images/products/product-template-image.png", 39 },
                    { 117, "/images/products/product-template-image.png", 39 },
                    { 118, "/images/products/product-template-image.png", 40 },
                    { 119, "/images/products/product-template-image.png", 40 },
                    { 120, "/images/products/product-template-image.png", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 33 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 34 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 35 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 36 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 37 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 38 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 39 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 40 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 31 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 32 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 33 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 34 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 35 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 36 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 37 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 38 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 39 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 40 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 31 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 32 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 33 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 34 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 35 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 36 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 37 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 38 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 39 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 40 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 31 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 32 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 33 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 34 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 35 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 36 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 37 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 38 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 39 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 40 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 31 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 32 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 33 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 34 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 35 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 36 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 37 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 38 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 39 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 40 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 31 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 32 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 33 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 34 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 35 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 36 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 37 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 38 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 39 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 40 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 23, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 25, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 28, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 29, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.InsertData(
                table: "ProductEntityTagEntity",
                columns: new[] { "ProductsId", "TagsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 }
                });
        }
    }
}
