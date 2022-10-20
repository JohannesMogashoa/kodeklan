using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class AsiveAddsMarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Marks");

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Marks");

            migrationBuilder.AddColumn<string>(
                name: "SubjectID",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
