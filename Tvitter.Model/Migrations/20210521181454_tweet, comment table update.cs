using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tvitter.Model.Migrations
{
    public partial class tweetcommenttableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tweets_IsComment",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "IsComment",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "CommentTweetId",
                table: "Comments");

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

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tags_TagId",
                table: "Comments",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tags_TagId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Comments_CommentID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentions_Comments_CommentID",
                table: "Mentions");

            migrationBuilder.DropIndex(
                name: "IX_Mentions_CommentID",
                table: "Mentions");

            migrationBuilder.DropIndex(
                name: "IX_Likes_CommentID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TagId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Mentions");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "IsComment",
                table: "Tweets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CommentTweetId",
                table: "Comments",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_IsComment",
                table: "Tweets",
                column: "IsComment");
        }
    }
}
