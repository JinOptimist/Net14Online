using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class Link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaveBuilding",
                table: "ApartmentOwners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HaveBuilding",
                table: "ApartmentOwners",
                type: "text",
                nullable: true);
        }
    }
}
