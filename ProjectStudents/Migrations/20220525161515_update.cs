using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectStudents.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Student_StudentId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Teacher_TeacherId",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_StudentId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Discipline");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Discipline",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DisciplineStudent",
                columns: table => new
                {
                    DisciplinesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineStudent", x => new { x.DisciplinesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_DisciplineStudent_Discipline_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStudent_StudentsId",
                table: "DisciplineStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Teacher_TeacherId",
                table: "Discipline",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Teacher_TeacherId",
                table: "Discipline");

            migrationBuilder.DropTable(
                name: "DisciplineStudent");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Discipline",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Discipline",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_StudentId",
                table: "Discipline",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Student_StudentId",
                table: "Discipline",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Teacher_TeacherId",
                table: "Discipline",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }
    }
}
