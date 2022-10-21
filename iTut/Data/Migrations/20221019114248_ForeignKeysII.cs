using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class ForeignKeysII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "EducatorID",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjID",
                table: "Marks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Marks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UploadedBy",
                table: "FilesOnDatabase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TopicID",
                table: "FilesOnDatabase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectID",
                table: "FilesOnDatabase",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_EducatorID",
                table: "Topics",
                column: "EducatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentID",
                table: "Marks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjID",
                table: "Marks",
                column: "SubjID");

            migrationBuilder.CreateIndex(
                name: "IX_FilesOnDatabase_SubjectID",
                table: "FilesOnDatabase",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_FilesOnDatabase_TopicID",
                table: "FilesOnDatabase",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_FilesOnDatabase_UploadedBy",
                table: "FilesOnDatabase",
                column: "UploadedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesOnDatabase_Educator_UploadedBy",
                table: "FilesOnDatabase",
                column: "UploadedBy",
                principalTable: "Educator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilesOnDatabase_Subjects_SubjectID",
                table: "FilesOnDatabase",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilesOnDatabase_Topics_TopicID",
                table: "FilesOnDatabase",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentID",
                table: "Marks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Subjects_SubjID",
                table: "Marks",
                column: "SubjID",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Educator_EducatorID",
                table: "Topics",
                column: "EducatorID",
                principalTable: "Educator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnDatabase_Educator_UploadedBy",
                table: "FilesOnDatabase");

            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnDatabase_Subjects_SubjectID",
                table: "FilesOnDatabase");

            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnDatabase_Topics_TopicID",
                table: "FilesOnDatabase");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentID",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Subjects_SubjID",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Educator_EducatorID",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_EducatorID",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Marks_StudentID",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_SubjID",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnDatabase_SubjectID",
                table: "FilesOnDatabase");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnDatabase_TopicID",
                table: "FilesOnDatabase");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnDatabase_UploadedBy",
                table: "FilesOnDatabase");

            migrationBuilder.AlterColumn<string>(
                name: "EducatorID",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjID",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "UploadedBy",
                table: "FilesOnDatabase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TopicID",
                table: "FilesOnDatabase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectID",
                table: "FilesOnDatabase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
