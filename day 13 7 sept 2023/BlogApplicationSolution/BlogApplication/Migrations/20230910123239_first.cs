using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApplication.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorsName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Pic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    BPost = table.Column<string>(type: "text", nullable: false),
                    Post_Publish_DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthorsName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoryTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagTitle = table.Column<string>(type: "text", nullable: false),
                    BlogPostId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoryTags_blogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "blogPosts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "AuthorsName", "Description", "Email", "Phone", "Pic" },
                values: new object[,]
                {
                    { 1, "ABC", "full time Blooger", "abc@gmail.com", "8856904770", "/images/pic1.png" },
                    { 2, "DEF", "Bloger on Social Media", "def@gmail.com", "8856904771", "/images/pic2.png" }
                });

            migrationBuilder.InsertData(
                table: "blogPosts",
                columns: new[] { "Id", "AuthorsName", "BPost", "Post_Publish_DateTime", "Title" },
                values: new object[,]
                {
                    { 1, "ABC", "blog, in full Web log or Weblog, online journal where an individual, group, or corporation presents a record of activities, thoughts, or beliefs. Some blogs operate mainly as news filters, collecting various online sources and adding short comments and Internet links. Other blogs concentrate on presenting original material. In addition, many blogs provide a forum to allow visitors to leave comments and interact with the publisher. “To blog” is the act of composing material for a blog. Materials are largely written, but pictures, audio, and videos are important elements of many blogs. The “blogosphere” is the online universe of blogs.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blog" },
                    { 2, "DEF", "The tiger has a muscular body with strong forelimbs, a large head and a tail that is about half the length of its body. Its pelage colouration varies between shades of orange with a white underside and distinctive vertical black stripes; the patterns of which are unique in each individual", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiger" }
                });

            migrationBuilder.InsertData(
                table: "categoryTags",
                columns: new[] { "Id", "BlogPostId", "TagTitle" },
                values: new object[,]
                {
                    { 1, null, "Social" },
                    { 2, null, "animal" },
                    { 3, null, "country" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoryTags_BlogPostId",
                table: "categoryTags",
                column: "BlogPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categoryTags");

            migrationBuilder.DropTable(
                name: "blogPosts");
        }
    }
}
