using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectEducators",
                table: "SubjectEducators");

            migrationBuilder.DropColumn(
                name: "SubjectEducatorId",
                table: "SubjectEducators");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubjectEducators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectEducators",
                table: "SubjectEducators",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectEducators",
                table: "SubjectEducators");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubjectEducators");

            migrationBuilder.AddColumn<string>(
                name: "SubjectEducatorId",
                table: "SubjectEducators",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectEducators",
                table: "SubjectEducators",
                column: "SubjectEducatorId");
        }
    }
}
