using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class ApartamentApartmentOwnerLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HaveBuilding",
                table: "ApartmentOwners",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentOwnerId",
                table: "Apartaments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_ApartmentOwnerId",
                table: "Apartaments",
                column: "ApartmentOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartaments_ApartmentOwners_ApartmentOwnerId",
                table: "Apartaments",
                column: "ApartmentOwnerId",
                principalTable: "ApartmentOwners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartaments_ApartmentOwners_ApartmentOwnerId",
                table: "Apartaments");

            migrationBuilder.DropIndex(
                name: "IX_Apartaments_ApartmentOwnerId",
                table: "Apartaments");

            migrationBuilder.DropColumn(
                name: "HaveBuilding",
                table: "ApartmentOwners");

            migrationBuilder.DropColumn(
                name: "ApartmentOwnerId",
                table: "Apartaments");
        }
    }
}
