using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Callisto.Domain.Infra.Migrations
{
    public partial class AddAssignedTechnicianToTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedTechnicianId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedTechnicianId",
                table: "Tickets",
                column: "AssignedTechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_User_AssignedTechnicianId",
                table: "Tickets",
                column: "AssignedTechnicianId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_User_AssignedTechnicianId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AssignedTechnicianId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AssignedTechnicianId",
                table: "Tickets");
        }
    }
}
