using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectStudents.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Learn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfGrade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learn", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Learn");
        }
    }
}
