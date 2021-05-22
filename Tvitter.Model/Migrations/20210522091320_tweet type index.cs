using Microsoft.EntityFrameworkCore.Migrations;

namespace Tvitter.Model.Migrations
{
    public partial class tweettypeindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tweets_Type",
                table: "Tweets",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tweets_Type",
                table: "Tweets");
        }
    }
}
