using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class FixLoginBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginBookingId",
                table: "Searches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClientsBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginsBooking", x => x.Id);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_Searches_LoginBookingId",
                table: "Searches",
                column: "LoginBookingId");

           
            migrationBuilder.AddForeignKey(
                name: "FK_Searches_LoginsBooking_LoginBookingId",
                table: "Searches",
                column: "LoginBookingId",
                principalTable: "ClientsBooking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Searches_LoginsBooking_LoginBookingId",
                table: "Searches");

            migrationBuilder.DropTable(
                name: "ClientsBooking");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SportGameTeam");

            migrationBuilder.DropTable(
                name: "SportGames");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Searches_LoginBookingId",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "LoginBookingId",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Heroes");
        }
    }
}
