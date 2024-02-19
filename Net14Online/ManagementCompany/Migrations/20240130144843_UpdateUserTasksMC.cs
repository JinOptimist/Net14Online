using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdateUserTasksMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExecutorId1",
                table: "UserTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_ExecutorId1",
                table: "UserTasks",
                column: "ExecutorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_ExecutorId1",
                table: "UserTasks",
                column: "ExecutorId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_ExecutorId1",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_ExecutorId1",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "ExecutorId1",
                table: "UserTasks");
        }
    }
}
