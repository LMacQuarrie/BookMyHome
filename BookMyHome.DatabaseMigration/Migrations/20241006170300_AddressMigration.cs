using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddressMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Door",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Floor",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_HouseNumber",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Address_ValidStatus",
                table: "Accommodations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address_Door",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address_Floor",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address_HouseNumber",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address_ValidStatus",
                table: "Accommodations");
        }
    }
}
