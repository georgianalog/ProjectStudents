using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectStudents.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_AspNetUsers_Id",
                table: "Teacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_Id",
                table: "Student",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_AspNetUsers_Id",
                table: "Teacher",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
