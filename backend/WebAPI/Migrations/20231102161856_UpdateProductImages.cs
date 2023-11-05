using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductEntitySizeEntity",
                columns: new[] { "AvailableSizesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 1, 26 },
                    { 1, 27 },
                    { 1, 28 },
                    { 1, 29 },
                    { 1, 30 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 2, 26 },
                    { 2, 27 },
                    { 2, 28 },
                    { 2, 29 },
                    { 2, 30 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 17 },
                    { 3, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 3, 21 },
                    { 3, 22 },
                    { 3, 23 },
                    { 3, 24 },
                    { 3, 25 },
                    { 3, 26 },
                    { 3, 27 },
                    { 3, 28 },
                    { 3, 29 },
                    { 3, 30 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 24 },
                    { 4, 25 },
                    { 4, 26 },
                    { 4, 27 },
                    { 4, 28 },
                    { 4, 29 },
                    { 4, 30 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 11 },
                    { 5, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 5, 16 },
                    { 5, 17 },
                    { 5, 18 },
                    { 5, 19 },
                    { 5, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 25 },
                    { 5, 26 },
                    { 5, 27 },
                    { 5, 28 },
                    { 5, 29 },
                    { 5, 30 },
                    { 6, 9 },
                    { 6, 10 },
                    { 6, 11 },
                    { 6, 12 },
                    { 6, 13 },
                    { 6, 14 },
                    { 6, 15 },
                    { 6, 16 },
                    { 6, 17 },
                    { 6, 18 },
                    { 6, 19 },
                    { 6, 20 },
                    { 6, 21 },
                    { 6, 22 },
                    { 6, 23 },
                    { 6, 24 },
                    { 6, 25 },
                    { 6, 26 },
                    { 6, 27 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 }
                });

            migrationBuilder.InsertData(
                table: "ProductEntityTagEntity",
                columns: new[] { "ProductsId", "TagsId" },
                values: new object[,]
                {
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 3 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 3 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 3 },
                    { 20, 1 },
                    { 20, 2 },
                    { 20, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Path", "ProductId" },
                values: new object[,]
                {
                    { 25, "/images/products/product-template-image.png", 9 },
                    { 26, "/images/products/product-template-image.png", 9 },
                    { 27, "/images/products/product-template-image.png", 9 },
                    { 28, "/images/products/product-template-image.png", 10 },
                    { 29, "/images/products/product-template-image.png", 10 },
                    { 30, "/images/products/product-template-image.png", 10 },
                    { 31, "/images/products/product-template-image.png", 11 },
                    { 32, "/images/products/product-template-image.png", 11 },
                    { 33, "/images/products/product-template-image.png", 11 },
                    { 34, "/images/products/product-template-image.png", 12 },
                    { 35, "/images/products/product-template-image.png", 12 },
                    { 36, "/images/products/product-template-image.png", 12 },
                    { 37, "/images/products/product-template-image.png", 13 },
                    { 38, "/images/products/product-template-image.png", 13 },
                    { 39, "/images/products/product-template-image.png", 13 },
                    { 40, "/images/products/product-template-image.png", 14 },
                    { 41, "/images/products/product-template-image.png", 14 },
                    { 42, "/images/products/product-template-image.png", 14 },
                    { 43, "/images/products/product-template-image.png", 15 },
                    { 44, "/images/products/product-template-image.png", 15 },
                    { 45, "/images/products/product-template-image.png", 15 },
                    { 46, "/images/products/product-template-image.png", 16 },
                    { 47, "/images/products/product-template-image.png", 16 },
                    { 48, "/images/products/product-template-image.png", 16 },
                    { 49, "/images/products/product-template-image.png", 17 },
                    { 50, "/images/products/product-template-image.png", 17 },
                    { 51, "/images/products/product-template-image.png", 17 },
                    { 52, "/images/products/product-template-image.png", 18 },
                    { 53, "/images/products/product-template-image.png", 18 },
                    { 54, "/images/products/product-template-image.png", 18 },
                    { 55, "/images/products/product-template-image.png", 19 },
                    { 56, "/images/products/product-template-image.png", 19 },
                    { 57, "/images/products/product-template-image.png", 19 },
                    { 58, "/images/products/product-template-image.png", 20 },
                    { 59, "/images/products/product-template-image.png", 20 },
                    { 60, "/images/products/product-template-image.png", 20 },
                    { 61, "/images/products/product-template-image.png", 21 },
                    { 62, "/images/products/product-template-image.png", 21 },
                    { 63, "/images/products/product-template-image.png", 21 },
                    { 64, "/images/products/product-template-image.png", 22 },
                    { 65, "/images/products/product-template-image.png", 22 },
                    { 66, "/images/products/product-template-image.png", 22 },
                    { 67, "/images/products/product-template-image.png", 23 },
                    { 68, "/images/products/product-template-image.png", 23 },
                    { 69, "/images/products/product-template-image.png", 23 },
                    { 70, "/images/products/product-template-image.png", 24 },
                    { 71, "/images/products/product-template-image.png", 24 },
                    { 72, "/images/products/product-template-image.png", 24 },
                    { 73, "/images/products/product-template-image.png", 25 },
                    { 74, "/images/products/product-template-image.png", 25 },
                    { 75, "/images/products/product-template-image.png", 25 },
                    { 76, "/images/products/product-template-image.png", 26 },
                    { 77, "/images/products/product-template-image.png", 26 },
                    { 78, "/images/products/product-template-image.png", 26 },
                    { 79, "/images/products/product-template-image.png", 27 },
                    { 80, "/images/products/product-template-image.png", 27 },
                    { 81, "/images/products/product-template-image.png", 27 },
                    { 82, "/images/products/product-template-image.png", 28 },
                    { 83, "/images/products/product-template-image.png", 28 },
                    { 84, "/images/products/product-template-image.png", 28 },
                    { 85, "/images/products/product-template-image.png", 29 },
                    { 86, "/images/products/product-template-image.png", 29 },
                    { 87, "/images/products/product-template-image.png", 29 },
                    { 88, "/images/products/product-template-image.png", 30 },
                    { 89, "/images/products/product-template-image.png", 30 },
                    { 90, "/images/products/product-template-image.png", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 28 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 29 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 26 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 29 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 2, 30 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 18 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 19 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 20 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 21 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 27 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 28 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 29 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 3, 30 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 24 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 26 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 27 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 28 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 29 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 4, 30 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 18 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 20 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 21 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 22 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 27 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 28 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 29 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 5, 30 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 15 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 19 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 20 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 21 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 22 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 23 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 24 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 25 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 26 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 27 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 28 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 29 });

            migrationBuilder.DeleteData(
                table: "ProductEntitySizeEntity",
                keyColumns: new[] { "AvailableSizesId", "ProductsId" },
                keyValues: new object[] { 6, 30 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "ProductEntityTagEntity",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 90);
        }
    }
}
