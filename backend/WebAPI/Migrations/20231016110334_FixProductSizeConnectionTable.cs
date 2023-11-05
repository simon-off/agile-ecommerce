using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixProductSizeConnectionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductEntityId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ProductEntityId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "Sizes");

            migrationBuilder.CreateTable(
                name: "ProductEntitySizeEntity",
                columns: table => new
                {
                    AvailableSizesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntitySizeEntity", x => new { x.AvailableSizesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductEntitySizeEntity_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntitySizeEntity_Sizes_AvailableSizesId",
                        column: x => x.AvailableSizesId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntitySizeEntity_ProductsId",
                table: "ProductEntitySizeEntity",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntitySizeEntity");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityId",
                table: "Sizes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductEntityId",
                table: "Sizes",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductEntityId",
                table: "Sizes",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
