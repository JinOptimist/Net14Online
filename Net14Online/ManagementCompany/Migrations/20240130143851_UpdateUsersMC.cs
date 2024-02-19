using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdateUsersMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_MemberStatuses_CompanyStatusId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Companies_CompanyId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_MemberPermissions_MemberPermissionId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_MemberStatuses_ExecutorStatusId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_MemberStatuses_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_UserStatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Executors_ExecutorStatusId",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "ExecutorStatusId",
                table: "Executors");

            migrationBuilder.RenameColumn(
                name: "UserStatusId",
                table: "Users",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                newName: "IX_Users_StatusId");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusId",
                table: "Projects",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                newName: "IX_Projects_StatusId");

            migrationBuilder.RenameColumn(
                name: "CompanyStatusId",
                table: "Companies",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CompanyStatusId",
                table: "Companies",
                newName: "IX_Companies_StatusId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberPermissionId",
                table: "Executors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Executors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Executors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Executors_StatusId",
                table: "Executors",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_MemberStatuses_StatusId",
                table: "Companies",
                column: "StatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Companies_CompanyId",
                table: "Executors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_MemberPermissions_MemberPermissionId",
                table: "Executors",
                column: "MemberPermissionId",
                principalTable: "MemberPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_MemberStatuses_StatusId",
                table: "Executors",
                column: "StatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_MemberStatuses_StatusId",
                table: "Projects",
                column: "StatusId",
                principalTable: "MemberStatuses",
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
                name: "FK_Companies_MemberStatuses_StatusId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Companies_CompanyId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_MemberPermissions_MemberPermissionId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_MemberStatuses_StatusId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_MemberStatuses_StatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Executors_StatusId",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Executors");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Users",
                newName: "UserStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                newName: "IX_Users_UserStatusId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Projects",
                newName: "ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                newName: "IX_Projects_ProjectStatusId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Companies",
                newName: "CompanyStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_StatusId",
                table: "Companies",
                newName: "IX_Companies_CompanyStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberPermissionId",
                table: "Executors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Executors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExecutorStatusId",
                table: "Executors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executors_ExecutorStatusId",
                table: "Executors",
                column: "ExecutorStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_MemberStatuses_CompanyStatusId",
                table: "Companies",
                column: "CompanyStatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Companies_CompanyId",
                table: "Executors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_MemberPermissions_MemberPermissionId",
                table: "Executors",
                column: "MemberPermissionId",
                principalTable: "MemberPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_MemberStatuses_ExecutorStatusId",
                table: "Executors",
                column: "ExecutorStatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_MemberStatuses_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberStatuses_UserStatusId",
                table: "Users",
                column: "UserStatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");
        }
    }
}
