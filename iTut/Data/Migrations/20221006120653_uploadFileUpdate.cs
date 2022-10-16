using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class uploadFileUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "FilesOnDatabase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "FilesOnDatabase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "FilesOnDatabase",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "FilesOnDatabase");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "FilesOnDatabase");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "FilesOnDatabase");
        }
    }
}
