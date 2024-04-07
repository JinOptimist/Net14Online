using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class CreateAlerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_ApartmentOwners_Id",
                        column: x => x.Id,
                        principalTable: "ApartmentOwners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlertApartmentOwner",
                columns: table => new
                {
                    NotificatedApartmentOwnersId = table.Column<int>(type: "integer", nullable: false),
                    SeenAlertsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertApartmentOwner", x => new { x.NotificatedApartmentOwnersId, x.SeenAlertsId });
                    table.ForeignKey(
                        name: "FK_AlertApartmentOwner_Alerts_SeenAlertsId",
                        column: x => x.SeenAlertsId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertApartmentOwner_ApartmentOwners_NotificatedApartmentOwn~",
                        column: x => x.NotificatedApartmentOwnersId,
                        principalTable: "ApartmentOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertApartmentOwner_SeenAlertsId",
                table: "AlertApartmentOwner",
                column: "SeenAlertsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertApartmentOwner");

            migrationBuilder.DropTable(
                name: "Alerts");
            
        }
    }
}
