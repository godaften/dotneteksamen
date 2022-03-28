using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Created", "Status", "Text", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6570), 0, "This is post 1", "Post no 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Created", "Status", "Text", "Title" },
                values: new object[] { 2, new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6610), 0, "This is post 2", "Post no 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Created", "Status", "Text", "Title" },
                values: new object[] { 3, new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6610), 0, "This is post 3", "Post no 3" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "PostId", "Text", "TimeStamp" },
                values: new object[] { 1, 1, "Hello", new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6720) });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "PostId", "Text", "TimeStamp" },
                values: new object[] { 2, 1, "Hello again", new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6730) });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "PostId", "Text", "TimeStamp" },
                values: new object[] { 3, 2, "Hi", new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6730) });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "PostId", "Text", "TimeStamp" },
                values: new object[] { 4, 3, "Bye", new DateTime(2022, 3, 28, 9, 30, 48, 334, DateTimeKind.Local).AddTicks(6730) });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
