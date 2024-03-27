using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateAlerts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreaterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Users_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlertUser",
                columns: table => new
                {
                    NotifiedUsersId = table.Column<int>(type: "int", nullable: false),
                    SeenAlertsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertUser", x => new { x.NotifiedUsersId, x.SeenAlertsId });
                    table.ForeignKey(
                        name: "FK_AlertUser_Alerts_SeenAlertsId",
                        column: x => x.SeenAlertsId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertUser_Users_NotifiedUsersId",
                        column: x => x.NotifiedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_CreaterId",
                table: "Alerts",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertUser_SeenAlertsId",
                table: "AlertUser",
                column: "SeenAlertsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertUser");

            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}
