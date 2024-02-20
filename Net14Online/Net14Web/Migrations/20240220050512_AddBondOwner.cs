using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddBondOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Bonds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bonds_OwnerId",
                table: "Bonds",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bonds_Users_OwnerId",
                table: "Bonds",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonds_Users_OwnerId",
                table: "Bonds");        

            migrationBuilder.DropIndex(
                name: "IX_Bonds_OwnerId",
                table: "Bonds");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Bonds");           
        }
    }
}
