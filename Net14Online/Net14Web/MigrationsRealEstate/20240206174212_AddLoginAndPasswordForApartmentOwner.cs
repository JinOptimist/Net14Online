using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.MigrationsRealEstate
{
    public partial class AddLoginAndPasswordForApartmentOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "ApartmentOwners",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ApartmentOwners",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "ApartmentOwners");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ApartmentOwners");
            
        }
    }
}
