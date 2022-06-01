using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccess.Migrations
{
    public partial class update886 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_user_Organizations_StudentId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "User_OrganizationId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_User_OrganizationId",
                table: "Reservations",
                column: "User_OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_user_Organizations_User_OrganizationId",
                table: "Reservations",
                column: "User_OrganizationId",
                principalTable: "user_Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_user_Organizations_User_OrganizationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_User_OrganizationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "User_OrganizationId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_user_Organizations_StudentId",
                table: "Reservations",
                column: "StudentId",
                principalTable: "user_Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
