using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net14Web.Migrations
{
    /// <inheritdoc />
    public partial class AddSimaticController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsedControllerId",
                table: "ScadaDataViewModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SimaticController",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rack = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimaticController", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScadaDataViewModels_UsedControllerId",
                table: "ScadaDataViewModels",
                column: "UsedControllerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScadaDataViewModels_SimaticController_UsedControllerId",
                table: "ScadaDataViewModels",
                column: "UsedControllerId",
                principalTable: "SimaticController",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScadaDataViewModels_SimaticController_UsedControllerId",
                table: "ScadaDataViewModels");

            migrationBuilder.DropTable(
                name: "SimaticController");

            migrationBuilder.DropIndex(
                name: "IX_ScadaDataViewModels_UsedControllerId",
                table: "ScadaDataViewModels");

            migrationBuilder.DropColumn(
                name: "UsedControllerId",
                table: "ScadaDataViewModels");
        }
    }
}
