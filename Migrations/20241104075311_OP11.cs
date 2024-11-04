using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPE.Migrations
{
    /// <inheritdoc />
    public partial class OP11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userData_AspNetUsers_UserId",
                table: "userData");

            migrationBuilder.DropTable(
                name: "slots");

            migrationBuilder.DropTable(
                name: "buckets");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userData",
                table: "userData");

            migrationBuilder.RenameTable(
                name: "userData",
                newName: "UserData");

            migrationBuilder.RenameIndex(
                name: "IX_userData_UserId",
                table: "UserData",
                newName: "IX_UserData_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_AspNetUsers_UserId",
                table: "UserData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_AspNetUsers_UserId",
                table: "UserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.RenameTable(
                name: "UserData",
                newName: "userData");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_UserId",
                table: "userData",
                newName: "IX_userData_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userData",
                table: "userData",
                column: "Id");

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
                    MaxVolume = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProducUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<int>(type: "int", nullable: false)
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
                    BucketID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CurrentSlotSize = table.Column<int>(type: "int", nullable: false),
                    DiscountInPercent = table.Column<int>(type: "int", nullable: false),
                    MaximumSlotSize = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_userData_AspNetUsers_UserId",
                table: "userData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
