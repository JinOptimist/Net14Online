using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class UpdateTableRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertRealEstateOwner_RealEstateOwners_NotificatedApartmentO~",
                table: "AlertRealEstateOwner");

            migrationBuilder.RenameColumn(
                name: "NotificatedApartmentOwnersId",
                table: "AlertRealEstateOwner",
                newName: "NotificatedRealEstateOwnersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertRealEstateOwner_RealEstateOwners_NotificatedRealEstate~",
                table: "AlertRealEstateOwner",
                column: "NotificatedRealEstateOwnersId",
                principalTable: "RealEstateOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertRealEstateOwner_RealEstateOwners_NotificatedRealEstate~",
                table: "AlertRealEstateOwner");

            migrationBuilder.RenameColumn(
                name: "NotificatedRealEstateOwnersId",
                table: "AlertRealEstateOwner",
                newName: "NotificatedApartmentOwnersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertRealEstateOwner_RealEstateOwners_NotificatedApartmentO~",
                table: "AlertRealEstateOwner",
                column: "NotificatedApartmentOwnersId",
                principalTable: "RealEstateOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
