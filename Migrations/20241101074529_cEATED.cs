using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPE.Migrations
{
    /// <inheritdoc />
    public partial class cEATED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buckets",
                columns: table => new
                {
                    BucketID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buckets", x => x.BucketID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxVolume = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<int>(type: "int", nullable: false),
                    ProducUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    SlotId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CurrentSlotSize = table.Column<int>(type: "int", nullable: false),
                    DiscountInPercent = table.Column<int>(type: "int", nullable: false),
                    MaximumSlotSize = table.Column<int>(type: "int", nullable: false),
                    BucketID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slots", x => x.SlotId);
                    table.ForeignKey(
                        name: "FK_slots_buckets_BucketID",
                        column: x => x.BucketID,
                        principalTable: "buckets",
                        principalColumn: "BucketID");
                    table.ForeignKey(
                        name: "FK_slots_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_slots_BucketID",
                table: "slots",
                column: "BucketID");

            migrationBuilder.CreateIndex(
                name: "IX_slots_ProductId",
                table: "slots",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slots");

            migrationBuilder.DropTable(
                name: "buckets");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
