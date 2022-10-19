using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class ANewAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "studentsId",
                table: "Marks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subjectId",
                table: "Marks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_studentsId",
                table: "Marks",
                column: "studentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_subjectId",
                table: "Marks",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_studentsId",
                table: "Marks",
                column: "studentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Subjects_subjectId",
                table: "Marks",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_studentsId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Subjects_subjectId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_studentsId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_subjectId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "studentsId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "subjectId",
                table: "Marks");
        }
    }
}
