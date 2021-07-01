using Microsoft.EntityFrameworkCore.Migrations;

namespace PSV2.Migrations
{
    public partial class Insturction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Users_DoctorId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_DoctorId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Instructions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Instructions");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Instructions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_DoctorId",
                table: "Instructions",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Users_DoctorId",
                table: "Instructions",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
