using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class UploadFileUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "FilesOnDatabase",
                newName: "TopicID");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "FilesOnDatabase",
                newName: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopicID",
                table: "FilesOnDatabase",
                newName: "Topic");

            migrationBuilder.RenameColumn(
                name: "SubjectID",
                table: "FilesOnDatabase",
                newName: "Subject");
        }
    }
}
