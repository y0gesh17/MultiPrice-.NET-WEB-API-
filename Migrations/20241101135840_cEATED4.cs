using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPE.Migrations
{
    /// <inheritdoc />
    public partial class cEATED4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "registerModel",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "registerModel",
                newName: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "registerModel",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "registerModel",
                newName: "Email");
        }
    }
}
