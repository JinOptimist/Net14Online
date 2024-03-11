using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdUsersMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "MemberPermissionId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users",
                column: "MemberPermissionId",
                principalTable: "MemberPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "MemberPermissionId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users",
                column: "MemberPermissionId",
                principalTable: "MemberPermissions",
                principalColumn: "Id");
        }
    }
}
