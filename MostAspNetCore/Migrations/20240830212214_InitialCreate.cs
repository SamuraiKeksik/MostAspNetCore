using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MostAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Coordinates = table.Column<string>(type: "TEXT", nullable: false),
                    BuildingName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BuildingTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProductPackageTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ArticleNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsFragile = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedsRefrigerator = table.Column<bool>(type: "INTEGER", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: true),
                    Height = table.Column<double>(type: "REAL", nullable: true),
                    Radius = table.Column<double>(type: "REAL", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DriverLicenseNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DriverLicenseExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DriverLicenseCategory = table.Column<string>(type: "TEXT", nullable: false),
                    Photo = table.Column<byte[]>(type: "BLOB", nullable: true),
                    CurrentRouteId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    PenaltyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PenaltyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.PenaltyId);
                    table.ForeignKey(
                        name: "FK_Penalties_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penalties_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransportId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrailerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Buildings = table.Column<string>(type: "TEXT", nullable: false),
                    Cargos = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    TrailerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    VinNumber = table.Column<string>(type: "TEXT", nullable: false),
                    LicensePlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TrailerTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxWeight = table.Column<double>(type: "REAL", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    TrailerAxesTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsibleDriverId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CurrentRouteId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.TrailerId);
                    table.ForeignKey(
                        name: "FK_Trailers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trailers_Drivers_ResponsibleDriverId",
                        column: x => x.ResponsibleDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_Trailers_Routes_CurrentRouteId",
                        column: x => x.CurrentRouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    TransportId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    VinNumber = table.Column<string>(type: "TEXT", nullable: false),
                    LicensePlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<double>(type: "REAL", nullable: true),
                    MaxFuel = table.Column<int>(type: "INTEGER", nullable: true),
                    TransportTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CanAttachTrailer = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxWeight = table.Column<double>(type: "REAL", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    AxesTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsibleDriverId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CurrentRouteId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.TransportId);
                    table.ForeignKey(
                        name: "FK_Transports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transports_Drivers_ResponsibleDriverId",
                        column: x => x.ResponsibleDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_Transports_Routes_CurrentRouteId",
                        column: x => x.CurrentRouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_UserId",
                table: "Buildings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CurrentRouteId",
                table: "Drivers",
                column: "CurrentRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_DriverId",
                table: "Penalties",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_UserId",
                table: "Penalties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DriverId",
                table: "Routes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TrailerId",
                table: "Routes",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TransportId",
                table: "Routes",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_UserId",
                table: "Routes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_CurrentRouteId",
                table: "Trailers",
                column: "CurrentRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_ResponsibleDriverId",
                table: "Trailers",
                column: "ResponsibleDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_UserId",
                table: "Trailers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_CurrentRouteId",
                table: "Transports",
                column: "CurrentRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_ResponsibleDriverId",
                table: "Transports",
                column: "ResponsibleDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_UserId",
                table: "Transports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Routes_CurrentRouteId",
                table: "Drivers",
                column: "CurrentRouteId",
                principalTable: "Routes",
                principalColumn: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trailers_TrailerId",
                table: "Routes",
                column: "TrailerId",
                principalTable: "Trailers",
                principalColumn: "TrailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Transports_TransportId",
                table: "Routes",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "TransportId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_UserId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_UserId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_AspNetUsers_UserId",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_AspNetUsers_UserId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Routes_CurrentRouteId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Routes_CurrentRouteId",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Routes_CurrentRouteId",
                table: "Transports");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Penalties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
