using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EducatorId",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EducatorId",
                table: "Feedbacks",
                column: "EducatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Educator_EducatorId",
                table: "Feedbacks",
                column: "EducatorId",
                principalTable: "Educator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Educator_EducatorId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_EducatorId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<string>(
                name: "EducatorId",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
