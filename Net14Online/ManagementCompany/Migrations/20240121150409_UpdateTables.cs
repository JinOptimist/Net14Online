using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPermission",
                table: "Users",
                newName: "MemberPermission");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Executors",
                newName: "MemberRole");

            migrationBuilder.RenameColumn(
                name: "UserPermission",
                table: "Executors",
                newName: "MemberPermission");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Executors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Executors");

            migrationBuilder.RenameColumn(
                name: "MemberPermission",
                table: "Users",
                newName: "UserPermission");

            migrationBuilder.RenameColumn(
                name: "MemberRole",
                table: "Executors",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "MemberPermission",
                table: "Executors",
                newName: "UserPermission");
        }
    }
}
