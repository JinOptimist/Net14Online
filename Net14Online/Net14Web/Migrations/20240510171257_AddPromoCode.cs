using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddPromoCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniquePromoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientBookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodes_ClientsBooking_ClientBookingId",
                        column: x => x.ClientBookingId,
                        principalTable: "ClientsBooking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_ClientBookingId",
                table: "PromoCodes",
                column: "ClientBookingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromoCodes");
        }
    }
}
