using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class FeedbackEduNeo10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "CreateAt",
            //    table: "FeedbackEducator",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "FeedbackContent",
            //    table: "FeedbackEducator",
            //    type: "nvarchar(max)",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "FeedbackEducator");

            migrationBuilder.DropColumn(
                name: "FeedbackContent",
                table: "FeedbackEducator");
        }
    }
}
