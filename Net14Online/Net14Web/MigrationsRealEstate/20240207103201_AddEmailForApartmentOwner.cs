using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.MigrationsRealEstate
{
    public partial class AddEmailForApartmentOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ApartmentOwners",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ApartmentOwners");
        }
    }
}
