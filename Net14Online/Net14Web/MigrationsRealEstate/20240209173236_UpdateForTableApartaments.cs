using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.MigrationsRealEstate
{
    public partial class UpdateForTableApartaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Apartaments");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Apartaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Apartaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberApartament",
                table: "Apartaments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Apartaments",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Apartaments");

            migrationBuilder.DropColumn(
                name: "NumberApartament",
                table: "Apartaments");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Apartaments");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Apartaments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Apartaments",
                type: "text",
                nullable: true);
        }
    }
}
