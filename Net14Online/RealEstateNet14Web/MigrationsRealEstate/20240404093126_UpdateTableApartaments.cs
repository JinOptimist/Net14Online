using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class UpdateTableApartaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Apartaments",
                type: "text",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Apartaments");
        }
    }
}
