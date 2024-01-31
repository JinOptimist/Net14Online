using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamWin",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "dbo",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamIDWin",
                schema: "dbo",
                table: "SportGames",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                schema: "dbo",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamIDWin",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeamWin",
                schema: "dbo",
                table: "SportGames",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
