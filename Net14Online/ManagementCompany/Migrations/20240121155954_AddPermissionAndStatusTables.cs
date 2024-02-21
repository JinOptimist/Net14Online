using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class AddPermissionAndStatusTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "MemberPermission",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MemberPermission",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "MemberRole",
                table: "Executors");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "UserTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberPermissionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserStatusId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectStatusId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutorStatusId",
                table: "Executors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Executors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MemberPermissionId",
                table: "Executors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyStatusId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_StatusId",
                table: "UserTasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberPermissionId",
                table: "Users",
                column: "MemberPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Executors_ExecutorStatusId",
                table: "Executors",
                column: "ExecutorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Executors_MemberPermissionId",
                table: "Executors",
                column: "MemberPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyStatusId",
                table: "Companies",
                column: "CompanyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_MemberStatuses_CompanyStatusId",
                table: "Companies",
                column: "CompanyStatusId",
                principalTable: "MemberStatuses",
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
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users",
                column: "MemberPermissionId",
                principalTable: "MemberPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberStatuses_UserStatusId",
                table: "Users",
                column: "UserStatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_TaskStatuses_StatusId",
                table: "UserTasks",
                column: "StatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_MemberStatuses_CompanyStatusId",
                table: "Companies");

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
                name: "FK_Users_MemberPermissions_MemberPermissionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_UserStatusId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_TaskStatuses_StatusId",
                table: "UserTasks");

            migrationBuilder.DropTable(
                name: "MemberPermissions");

            migrationBuilder.DropTable(
                name: "MemberStatuses");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_StatusId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_Users_MemberPermissionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserStatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Executors_ExecutorStatusId",
                table: "Executors");

            migrationBuilder.DropIndex(
                name: "IX_Executors_MemberPermissionId",
                table: "Executors");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyStatusId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "MemberPermissionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ExecutorStatusId",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "MemberPermissionId",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "CompanyStatusId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberPermission",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberPermission",
                table: "Executors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberRole",
                table: "Executors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
