using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdateUserTaskAddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserTasks");
        }
    }
}
