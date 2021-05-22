using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tvitter.Model.Migrations
{
    public partial class commenttabledeletedtweettableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Comments_CommentID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentions_Comments_CommentID",
                table: "Mentions");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Mentions_CommentID",
                table: "Mentions");

            migrationBuilder.DropIndex(
                name: "IX_Likes_CommentID",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Mentions");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Likes");

            migrationBuilder.AddColumn<Guid>(
                name: "BelongsTo",
                table: "Tweets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_BelongsTo",
                table: "Tweets",
                column: "BelongsTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tweets_BelongsTo",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "BelongsTo",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tweets");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentID",
                table: "Mentions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CommentID",
                table: "Likes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MediaUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mentions_CommentID",
                table: "Mentions",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentID",
                table: "Likes",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TagId",
                table: "Comments",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TweetId",
                table: "Comments",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Comments_CommentID",
                table: "Likes",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentions_Comments_CommentID",
                table: "Mentions",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
