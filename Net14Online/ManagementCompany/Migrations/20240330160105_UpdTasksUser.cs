using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdTasksUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskStatus",
                table: "UserTaskStatus");

            migrationBuilder.RenameTable(
                name: "UserTaskStatus",
                newName: "TaskStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskStatus_Status",
                table: "TaskStatuses",
                newName: "IX_TaskStatuses_Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    ExecutorId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_TaskStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AuthorId",
                table: "UserTasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_ExecutorId",
                table: "UserTasks",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_StatusId",
                table: "UserTasks",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses");

            migrationBuilder.RenameTable(
                name: "TaskStatuses",
                newName: "UserTaskStatus");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatuses_Status",
                table: "UserTaskStatus",
                newName: "IX_UserTaskStatus_Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskStatus",
                table: "UserTaskStatus",
                column: "Id");
        }
    }
}
