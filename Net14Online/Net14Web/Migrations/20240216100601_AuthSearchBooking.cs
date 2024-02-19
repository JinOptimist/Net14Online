using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AuthSearchBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "LoginBookingId",
                table: "Searches",
                newName: "ClientBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Searches_LoginBookingId",
                table: "Searches",
                newName: "IX_Searches_ClientBookingId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Searches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Searches_OwnerId",
                table: "Searches",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_ClientsBooking_ClientBookingId",
                table: "Searches",
                column: "ClientBookingId",
                principalTable: "ClientsBooking",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_Users_OwnerId",
                table: "Searches",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Searches_ClientsBooking_ClientBookingId",
                table: "Searches");

            migrationBuilder.DropForeignKey(
                name: "FK_Searches_Users_OwnerId",
                table: "Searches");

            migrationBuilder.DropIndex(
                name: "IX_Searches_OwnerId",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Searches");

            migrationBuilder.RenameColumn(
                name: "ClientBookingId",
                table: "Searches",
                newName: "LoginBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Searches_ClientBookingId",
                table: "Searches",
                newName: "IX_Searches_LoginBookingId");

        }
    }
}
