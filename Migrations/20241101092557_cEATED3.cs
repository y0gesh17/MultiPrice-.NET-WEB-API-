using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPE.Migrations
{
    /// <inheritdoc />
    public partial class cEATED3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registerModel_AspNetRoles_RoleId",
                table: "registerModel");

            migrationBuilder.DropIndex(
                name: "IX_registerModel_RoleId",
                table: "registerModel");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "registerModel");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "registerModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "registerModel");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "registerModel",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_registerModel_RoleId",
                table: "registerModel",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_registerModel_AspNetRoles_RoleId",
                table: "registerModel",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
