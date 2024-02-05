using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_OwnerId",
                table: "Heroes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Users_OwnerId",
                table: "Heroes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Users_OwnerId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_OwnerId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Heroes");
        }
    }
}
