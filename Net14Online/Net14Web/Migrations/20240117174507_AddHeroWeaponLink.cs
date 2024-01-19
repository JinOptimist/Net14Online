using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroWeaponLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteWeaponId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_FavoriteWeaponId",
                table: "Heroes",
                column: "FavoriteWeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Weapons_FavoriteWeaponId",
                table: "Heroes",
                column: "FavoriteWeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Weapons_FavoriteWeaponId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_FavoriteWeaponId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "FavoriteWeaponId",
                table: "Heroes");
        }
    }
}
