using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    public partial class UpdateAlerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_ApartmentOwners_Id",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Alerts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Alerts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_CreatorId",
                table: "Alerts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_ApartmentOwners_CreatorId",
                table: "Alerts",
                column: "CreatorId",
                principalTable: "ApartmentOwners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_ApartmentOwners_CreatorId",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_CreatorId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Alerts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_ApartmentOwners_Id",
                table: "Alerts",
                column: "Id",
                principalTable: "ApartmentOwners",
                principalColumn: "Id");
        }
    }
}
