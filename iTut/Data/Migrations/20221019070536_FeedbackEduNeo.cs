using Microsoft.EntityFrameworkCore.Migrations;

namespace iTut.Data.Migrations
{
    public partial class FeedbackEduNeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "FeedbackEducator",
            //    columns: table => new
            //    {
            //        FeedbackEducatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EducatorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FeedbackEducator", x => x.FeedbackEducatorId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackEducator");
        }
    }
}
