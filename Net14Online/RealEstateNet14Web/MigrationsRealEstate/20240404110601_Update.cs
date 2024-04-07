using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_ApartmentOwners_CreatorId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "AlertApartmentOwner");

            migrationBuilder.DropTable(
                name: "Apartaments");

            migrationBuilder.DropTable(
                name: "ApartmentOwners");

            migrationBuilder.CreateTable(
                name: "RealEstateOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    KindOfActivity = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertRealEstateOwner",
                columns: table => new
                {
                    NotificatedApartmentOwnersId = table.Column<int>(type: "integer", nullable: false),
                    SeenAlertsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertRealEstateOwner", x => new { x.NotificatedApartmentOwnersId, x.SeenAlertsId });
                    table.ForeignKey(
                        name: "FK_AlertRealEstateOwner_Alerts_SeenAlertsId",
                        column: x => x.SeenAlertsId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertRealEstateOwner_RealEstateOwners_NotificatedApartmentO~",
                        column: x => x.NotificatedApartmentOwnersId,
                        principalTable: "RealEstateOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    NumberApartament = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    RealEstateOwnerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstates_RealEstateOwners_RealEstateOwnerId",
                        column: x => x.RealEstateOwnerId,
                        principalTable: "RealEstateOwners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertRealEstateOwner_SeenAlertsId",
                table: "AlertRealEstateOwner",
                column: "SeenAlertsId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_RealEstateOwnerId",
                table: "RealEstates",
                column: "RealEstateOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_RealEstateOwners_CreatorId",
                table: "Alerts",
                column: "CreatorId",
                principalTable: "RealEstateOwners",
                principalColumn: "Id");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_RealEstateOwners_CreatorId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "AlertRealEstateOwner");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "RealEstateOwners");

            migrationBuilder.CreateTable(
                name: "ApartmentOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    KindOfActivity = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentOwners", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Apartaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApartmentOwnerId = table.Column<int>(type: "integer", nullable: true),
                    City = table.Column<string>(type: "text", nullable: false),
                    NumberApartament = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartaments_ApartmentOwners_ApartmentOwnerId",
                        column: x => x.ApartmentOwnerId,
                        principalTable: "ApartmentOwners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertApartmentOwner_SeenAlertsId",
                table: "AlertApartmentOwner",
                column: "SeenAlertsId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_ApartmentOwnerId",
                table: "Apartaments",
                column: "ApartmentOwnerId");
            

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_ApartmentOwners_CreatorId",
                table: "Alerts",
                column: "CreatorId",
                principalTable: "ApartmentOwners",
                principalColumn: "Id");
        }
    }
}
