using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdateStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberStatuses_Status",
                table: "MemberStatuses");

            migrationBuilder.DropIndex(
                name: "IX_MemberPermissions_Permission",
                table: "MemberPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MemberStatuses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "MemberPermissions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_MemberStatuses_Status",
                table: "MemberStatuses",
                column: "Status",
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPermissions_Permission",
                table: "MemberPermissions",
                column: "Permission",
                unique: true,
                filter: "[Permission] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberStatuses_Status",
                table: "MemberStatuses");

            migrationBuilder.DropIndex(
                name: "IX_MemberPermissions_Permission",
                table: "MemberPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MemberStatuses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "MemberPermissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberStatuses_Status",
                table: "MemberStatuses",
                column: "Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberPermissions_Permission",
                table: "MemberPermissions",
                column: "Permission",
                unique: true);
        }
    }
}
