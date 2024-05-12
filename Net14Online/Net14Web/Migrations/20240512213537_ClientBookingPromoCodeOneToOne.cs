using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class ClientBookingPromoCodeOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_ClientsBooking_ClientBookingId",
                table: "PromoCodes");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_ClientsBooking_ClientBookingId",
                table: "PromoCodes",
                column: "ClientBookingId",
                principalTable: "ClientsBooking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_ClientsBooking_ClientBookingId",
                table: "PromoCodes");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_ClientsBooking_ClientBookingId",
                table: "PromoCodes",
                column: "ClientBookingId",
                principalTable: "ClientsBooking",
                principalColumn: "Id");
        }
    }
}
