using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class ChangeUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_UserId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTasks",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId",
                table: "UserTasks",
                newName: "IX_UserTasks_AuthorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "UserTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_AuthorId",
                table: "UserTasks",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_AuthorId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "UserTasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_AuthorId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
