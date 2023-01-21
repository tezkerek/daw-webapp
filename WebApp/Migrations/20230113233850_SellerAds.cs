using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SellerAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seller_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ad_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdUser",
                columns: table => new
                {
                    FavoriteAdsId = table.Column<Guid>(type: "uuid", nullable: false),
                    WatchingUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdUser", x => new { x.FavoriteAdsId, x.WatchingUsersId });
                    table.ForeignKey(
                        name: "FK_AdUser_Ad_FavoriteAdsId",
                        column: x => x.FavoriteAdsId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdUser_AspNetUsers_WatchingUsersId",
                        column: x => x.WatchingUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_SellerId",
                table: "Ad",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUser_WatchingUsersId",
                table: "AdUser",
                column: "WatchingUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_Name",
                table: "Seller",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_UserId",
                table: "Seller",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdUser");

            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
