using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MostAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteStartBuildingProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Routes_RouteId",
                table: "Buildings");


            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Buildings");

            migrationBuilder.AddColumn<Guid>(
                name: "StartBuildingBuildingId",
                table: "Routes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartBuildingBuildingId",
                table: "Routes",
                column: "StartBuildingBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Buildings_StartBuildingBuildingId",
                table: "Routes",
                column: "StartBuildingBuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Buildings_StartBuildingBuildingId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_StartBuildingBuildingId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartBuildingBuildingId",
                table: "Routes");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Buildings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_RouteId",
                table: "Buildings",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Routes_RouteId",
                table: "Buildings",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId");
        }
    }
}
