using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Callisto.Domain.Infra.Migrations
{
    [Migration("20260305120000_AddTicketTechnician")]
    public partial class AddTicketTechnician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TechnicianId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TechnicianId",
                table: "Tickets",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_User_TechnicianId",
                table: "Tickets",
                column: "TechnicianId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_User_TechnicianId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TechnicianId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "Tickets");
        }
    }
}
