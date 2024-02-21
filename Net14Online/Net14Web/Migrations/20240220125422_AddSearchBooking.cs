using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddSearchBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameComments_Games_CommentedGameId",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Searches_LoginsBooking_LoginBookingId",
                table: "Searches");

            migrationBuilder.DropTable(
                name: "LoginsBooking");

            migrationBuilder.RenameColumn(
                name: "LoginBookingId",
                table: "Searches",
                newName: "ClientBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Searches_LoginBookingId",
                table: "Searches",
                newName: "IX_Searches_ClientBookingId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Searches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientsBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsBooking_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Searches_OwnerId",
                table: "Searches",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsBooking_OwnerId",
                table: "ClientsBooking",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameComments_Games_CommentedGameId",
                table: "GameComments",
                column: "CommentedGameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_ClientsBooking_ClientBookingId",
                table: "Searches",
                column: "ClientBookingId",
                principalTable: "ClientsBooking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_Users_OwnerId",
                table: "Searches",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameComments_Games_CommentedGameId",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Searches_ClientsBooking_ClientBookingId",
                table: "Searches");

            migrationBuilder.DropForeignKey(
                name: "FK_Searches_Users_OwnerId",
                table: "Searches");

            migrationBuilder.DropTable(
                name: "ClientsBooking");

            migrationBuilder.DropIndex(
                name: "IX_Searches_OwnerId",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Searches");

            migrationBuilder.RenameColumn(
                name: "ClientBookingId",
                table: "Searches",
                newName: "LoginBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Searches_ClientBookingId",
                table: "Searches",
                newName: "IX_Searches_LoginBookingId");

            migrationBuilder.CreateTable(
                name: "LoginsBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginsBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginsBooking_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginsBooking_OwnerId",
                table: "LoginsBooking",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameComments_Games_CommentedGameId",
                table: "GameComments",
                column: "CommentedGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_LoginsBooking_LoginBookingId",
                table: "Searches",
                column: "LoginBookingId",
                principalTable: "LoginsBooking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
