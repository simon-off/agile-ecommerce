using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 9, 1, "Elevate your style with our stylish dress shirt. Perfect for formal occasions or office wear, this shirt is designed for both comfort and fashion.", "Stylish Dress Shirt", 49.99m },
                    { 10, 2, "Stay cozy and fashionable in our warm winter jacket. It's designed to keep you toasty in cold weather while making a style statement.", "Warm Winter Jacket", 89.99m },
                    { 11, 3, "Go for a relaxed yet stylish look with our casual chino pants. These comfortable pants are versatile for various occasions.", "Casual Chino Pants", 34.99m },
                    { 12, 4, "Step into timeless elegance with our classic leather loafers. These comfortable and stylish shoes are perfect for any formal event.", "Classic Leather Loafers", 69.99m },
                    { 13, 5, "Complete your look with our trendy baseball cap. It's not only a practical accessory but also a fashionable addition to your outfit.", "Trendy Baseball Cap", 19.99m },
                    { 14, 6, "Protect your eyes in style with our fashionable sunglasses. These shades offer both UV protection and a trendy look.", "Fashionable Sunglasses", 29.99m },
                    { 15, 7, "Make a grand entrance in our elegant evening gown. This gown is designed with sophistication in mind and is perfect for formal events.", "Elegant Evening Gown", 149.99m },
                    { 16, 8, "Experience ultimate comfort with our boxer briefs. Made from soft, breathable fabric, they're perfect for everyday wear.", "Comfortable Boxer Briefs", 14.99m },
                    { 17, 9, "Upgrade your wardrobe with our modern slim-fit suit. It's tailored to perfection, exuding confidence and style. Ideal for formal occasions.", "Modern Slim-fit Suit", 199.99m },
                    { 18, 1, "Achieve a classic look with our crisp white dress shirt. It's a versatile piece that pairs well with various suits and ties.", "Crisp White Dress Shirt", 39.99m },
                    { 19, 2, "Stay prepared for changing weather with our all-weather jacket. It's designed to protect you from the elements without sacrificing style.", "All-Weather Jacket", 79.99m },
                    { 20, 3, "Find flexibility and comfort in our stretchy yoga pants. They're perfect for yoga sessions or lounging at home.", "Stretchy Yoga Pants", 24.99m },
                    { 21, 4, "Embark on outdoor adventures with confidence in our hiking boots. These sturdy boots are designed for traction and support on rugged terrain.", "Hiking Boots", 79.99m },
                    { 22, 5, "Stay warm and stylish with our cozy beanie hat. It's the perfect accessory to keep you snug during the colder months.", "Cozy Beanie Hat", 14.99m },
                    { 23, 6, "Organize your essentials in style with our leather wallet. It's a fashionable and functional accessory for everyday use.", "Leather Wallet", 34.99m },
                    { 24, 7, "Embrace the beauty of floral patterns with our floral maxi dress. It's perfect for a stylish, feminine look on special occasions.", "Floral Maxi Dress", 59.99m },
                    { 25, 8, "Indulge in luxury with our silk boxer shorts. They offer a premium feel and comfort for a touch of sophistication.", "Silk Boxer Shorts", 24.99m },
                    { 26, 9, "Make a statement with our three-piece suit set. It includes a jacket, vest, and pants, perfect for formal events and weddings.", "Three-Piece Suit Set", 249.99m },
                    { 27, 1, "Add a touch of sophistication with our striped button-down shirt. It's a versatile piece that suits both casual and formal occasions.", "Striped Button-Down Shirt", 44.99m },
                    { 28, 2, "Stay warm in style with our quilted winter coat. It's designed for cold weather and features a flattering silhouette.", "Quilted Winter Coat", 99.99m },
                    { 29, 3, "Get ready for adventure in our cargo pants. These functional and durable pants are perfect for outdoor activities.", "Cargo Pants", 39.99m },
                    { 30, 4, "Step out in elegance with our suede Chelsea boots. These stylish boots are ideal for both casual and semi-formal occasions.", "Suede Chelsea Boots", 69.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
