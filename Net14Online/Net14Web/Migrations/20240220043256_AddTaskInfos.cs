using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "TaskInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskInfos_OwnerId",
                table: "TaskInfos",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInfos_Users_OwnerId",
                table: "TaskInfos",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskInfos_Users_OwnerId",
                table: "TaskInfos");

            migrationBuilder.DropIndex(
                name: "IX_TaskInfos_OwnerId",
                table: "TaskInfos");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "TaskInfos");
        }
    }
}
