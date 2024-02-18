using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginBookingOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "LoginsBooking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginsBooking_OwnerId",
                table: "LoginsBooking",
                column: "OwnerId");


            migrationBuilder.AddForeignKey(
                name: "FK_LoginsBooking_Users_OwnerId",
                table: "LoginsBooking",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_LoginsBooking_Users_OwnerId",
                table: "LoginsBooking");

            migrationBuilder.DropIndex(
                name: "IX_LoginsBooking_OwnerId",
                table: "LoginsBooking");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "LoginsBooking");
        }
    }
}
