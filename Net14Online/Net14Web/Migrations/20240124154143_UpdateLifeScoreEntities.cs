using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLifeScoreEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportGames_Teams_TeamId",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGames_Teams_TeamId1",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropIndex(
                name: "IX_SportGames_TeamId",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropIndex(
                name: "IX_SportGames_TeamId1",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropColumn(
                name: "Team1Id",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropColumn(
                name: "Team2Id",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropColumn(
                name: "TeamId",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                schema: "dbo",
                table: "SportGames");

            migrationBuilder.RenameTable(
                name: "Teams",
                schema: "dbo",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "SportGames",
                schema: "dbo",
                newName: "SportGames");

            migrationBuilder.RenameTable(
                name: "Players",
                schema: "dbo",
                newName: "Players");

            migrationBuilder.CreateTable(
                name: "SportGameTeam",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportGameTeam", x => new { x.GamesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_SportGameTeam_SportGames_GamesId",
                        column: x => x.GamesId,
                        principalTable: "SportGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportGameTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportGameTeam_TeamsId",
                table: "SportGameTeam",
                column: "TeamsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportGameTeam");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Teams",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SportGames",
                newName: "SportGames",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Players",
                newSchema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "Team1Id",
                schema: "dbo",
                table: "SportGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team2Id",
                schema: "dbo",
                table: "SportGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                schema: "dbo",
                table: "SportGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                schema: "dbo",
                table: "SportGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportGames_TeamId",
                schema: "dbo",
                table: "SportGames",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SportGames_TeamId1",
                schema: "dbo",
                table: "SportGames",
                column: "TeamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SportGames_Teams_TeamId",
                schema: "dbo",
                table: "SportGames",
                column: "TeamId",
                principalSchema: "dbo",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SportGames_Teams_TeamId1",
                schema: "dbo",
                table: "SportGames",
                column: "TeamId1",
                principalSchema: "dbo",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
