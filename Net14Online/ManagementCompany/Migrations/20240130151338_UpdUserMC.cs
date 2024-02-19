using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    /// <inheritdoc />
    public partial class UpdUserMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberStatuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "MemberStatuses",
                principalColumn: "Id");
        }
    }
}
