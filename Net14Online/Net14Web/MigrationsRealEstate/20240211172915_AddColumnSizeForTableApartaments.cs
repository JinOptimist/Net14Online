using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.MigrationsRealEstate
{
    public partial class AddColumnSizeForTableApartaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Apartaments",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Apartaments");
        }
    }
}
