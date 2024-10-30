using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MostAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDriverLicenseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverLicenseCategory",
                table: "Drivers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverLicenseCategory",
                table: "Drivers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
