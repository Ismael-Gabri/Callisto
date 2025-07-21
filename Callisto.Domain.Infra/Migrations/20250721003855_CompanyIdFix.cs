using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Callisto.Domain.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CompanyIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Companies_CompanyId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CompanyId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId1",
                table: "User",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Companies_CompanyId1",
                table: "User",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
