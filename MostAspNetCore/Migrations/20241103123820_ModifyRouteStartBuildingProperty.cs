using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MostAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRouteStartBuildingProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Buildings_StartBuildingBuildingId",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "StartBuildingBuildingId",
                table: "Routes",
                newName: "StartBuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_StartBuildingBuildingId",
                table: "Routes",
                newName: "IX_Routes_StartBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Buildings_StartBuildingId",
                table: "Routes",
                column: "StartBuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Buildings_StartBuildingId",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "StartBuildingId",
                table: "Routes",
                newName: "StartBuildingBuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_StartBuildingId",
                table: "Routes",
                newName: "IX_Routes_StartBuildingBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Buildings_StartBuildingBuildingId",
                table: "Routes",
                column: "StartBuildingBuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
