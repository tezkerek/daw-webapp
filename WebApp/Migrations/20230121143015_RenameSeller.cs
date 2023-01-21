using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Seller_SellerId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_AdUser_Ad_FavoriteAdsId",
                table: "AdUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Seller_AspNetUsers_UserId",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ad",
                table: "Ad");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Ad",
                newName: "Ads");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_UserId",
                table: "Sellers",
                newName: "IX_Sellers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_Name",
                table: "Sellers",
                newName: "IX_Sellers_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_SellerId",
                table: "Ads",
                newName: "IX_Ads_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Sellers_SellerId",
                table: "Ads",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdUser_Ads_FavoriteAdsId",
                table: "AdUser",
                column: "FavoriteAdsId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AspNetUsers_UserId",
                table: "Sellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Sellers_SellerId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_AdUser_Ads_FavoriteAdsId",
                table: "AdUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AspNetUsers_UserId",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "Ads",
                newName: "Ad");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_UserId",
                table: "Seller",
                newName: "IX_Seller_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_Name",
                table: "Seller",
                newName: "IX_Seller_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_SellerId",
                table: "Ad",
                newName: "IX_Ad_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ad",
                table: "Ad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Seller_SellerId",
                table: "Ad",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdUser_Ad_FavoriteAdsId",
                table: "AdUser",
                column: "FavoriteAdsId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_AspNetUsers_UserId",
                table: "Seller",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
