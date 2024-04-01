using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlertModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "Alerts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Alerts",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Alerts");
        }
    }
}
