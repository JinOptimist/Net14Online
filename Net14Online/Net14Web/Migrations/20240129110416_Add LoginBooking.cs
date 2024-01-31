using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginBooking : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Searches_LoginBookingId",
                table: "Searches",
                column: "LoginBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_LoginsBooking_LoginBookingId",
                table: "Searches",
                column: "LoginBookingId",
                principalTable: "LoginsBooking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Searches_LoginsBooking_LoginBookingId",
                table: "Searches");

            migrationBuilder.DropIndex(
                name: "IX_Searches_LoginBookingId",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "LoginBookingId",
                table: "Searches");
        }
    }
}
