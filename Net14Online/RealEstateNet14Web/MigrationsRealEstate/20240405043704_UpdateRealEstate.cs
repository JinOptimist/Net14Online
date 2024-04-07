using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class UpdateRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberApartament",
                table: "RealEstates");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "RealEstates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeRealEstate",
                table: "RealEstates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "TypeRealEstate",
                table: "RealEstates");

            migrationBuilder.AddColumn<int>(
                name: "NumberApartament",
                table: "RealEstates",
                type: "integer",
                nullable: true);
        }
    }
}
