using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddKnowsWeaponToHero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroWeapon",
                columns: table => new
                {
                    HeroesWhoKnowsTheWeaponId = table.Column<int>(type: "int", nullable: false),
                    KnowedWeaponsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroWeapon", x => new { x.HeroesWhoKnowsTheWeaponId, x.KnowedWeaponsId });
                    table.ForeignKey(
                        name: "FK_HeroWeapon_Heroes_HeroesWhoKnowsTheWeaponId",
                        column: x => x.HeroesWhoKnowsTheWeaponId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroWeapon_Weapons_KnowedWeaponsId",
                        column: x => x.KnowedWeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroWeapon_KnowedWeaponsId",
                table: "HeroWeapon",
                column: "KnowedWeaponsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroWeapon");
        }
    }
}
