using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class FixUsersv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
