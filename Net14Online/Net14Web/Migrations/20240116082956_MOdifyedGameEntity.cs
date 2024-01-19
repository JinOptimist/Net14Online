using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class ModifyedGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Genre",
                table: "Games",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Raiting",
                table: "Games",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Raiting",
                table: "Games");
        }
    }
}
