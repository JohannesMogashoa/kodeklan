using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class SubjEdNeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "SubjectId",
            //    table: "SubjectEducators",
            //    type: "nvarchar(450)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "EducatorId",
            //    table: "SubjectEducators",
            //    type: "nvarchar(450)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Grade",
            //    table: "SubjectEducators",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubjectEducators_EducatorId",
            //    table: "SubjectEducators",
            //    column: "EducatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubjectEducators_SubjectId",
            //    table: "SubjectEducators",
            //    column: "SubjectId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubjectEducators_Educator_EducatorId",
            //    table: "SubjectEducators",
            //    column: "EducatorId",
            //    principalTable: "Educator",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubjectEducators_Subjects_SubjectId",
            //    table: "SubjectEducators",
            //    column: "SubjectId",
            //    principalTable: "Subjects",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectEducators_Educator_EducatorId",
                table: "SubjectEducators");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectEducators_Subjects_SubjectId",
                table: "SubjectEducators");

            migrationBuilder.DropIndex(
                name: "IX_SubjectEducators_EducatorId",
                table: "SubjectEducators");

            migrationBuilder.DropIndex(
                name: "IX_SubjectEducators_SubjectId",
                table: "SubjectEducators");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "SubjectEducators");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectEducators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducatorId",
                table: "SubjectEducators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
