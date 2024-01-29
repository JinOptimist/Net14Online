using Microsoft.EntityFrameworkCore.Migrations;
using Net14Web.DbStuff.Models.Enums;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddRaceForHero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Race",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: Race.Human);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Race",
                table: "Heroes");
        }
    }
}
