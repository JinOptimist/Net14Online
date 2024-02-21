using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdateTablesMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Executors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executors_CompanyId",
                table: "Executors",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Companies_CompanyId",
                table: "Executors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Companies_CompanyId",
                table: "Executors");

            migrationBuilder.DropIndex(
                name: "IX_Executors_CompanyId",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Executors");
        }
    }
}
