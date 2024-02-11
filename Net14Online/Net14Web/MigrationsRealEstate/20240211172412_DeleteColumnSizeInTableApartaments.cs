using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.MigrationsRealEstate
{
    public partial class DeleteColumnSizeInTableApartaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Apartaments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Apartaments",
                type: "integer",
                nullable: true);
        }
    }
}
