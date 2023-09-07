using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorsName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Pic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "blogPosts",
                columns: table => new
                {
                    BlogPostId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    BPost = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogPosts", x => x.BlogPostId);
                    table.ForeignKey(
                        name: "FK_blogPosts_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoryTags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagTitle = table.Column<string>(type: "text", nullable: false),
                    BlogPostId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryTags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_categoryTags_blogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "blogPosts",
                        principalColumn: "BlogPostId");
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "AuthorId", "AuthorsName", "Description", "Email", "Pic" },
                values: new object[,]
                {
                    { 1, "ABC", "full time Blooger", "abc@gmail.com", "/images/pic1.png" },
                    { 2, "DEF", "Bloger on Social Media", "def@gmail.com", "/images/pic2.png" }
                });

            migrationBuilder.InsertData(
                table: "categoryTags",
                columns: new[] { "TagId", "BlogPostId", "TagTitle" },
                values: new object[,]
                {
                    { 1, null, "Social" },
                    { 2, null, "animal" },
                    { 3, null, "country" }
                });

            migrationBuilder.InsertData(
                table: "blogPosts",
                columns: new[] { "BlogPostId", "AuthorId", "BPost", "TagId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "blog, in full Web log or Weblog, online journal where an individual, group, or corporation presents a record of activities, thoughts, or beliefs. Some blogs operate mainly as news filters, collecting various online sources and adding short comments and Internet links. Other blogs concentrate on presenting original material. In addition, many blogs provide a forum to allow visitors to leave comments and interact with the publisher. “To blog” is the act of composing material for a blog. Materials are largely written, but pictures, audio, and videos are important elements of many blogs. The “blogosphere” is the online universe of blogs.", 1, "Blog" },
                    { 2, 2, "The tiger has a muscular body with strong forelimbs, a large head and a tail that is about half the length of its body. Its pelage colouration varies between shades of orange with a white underside and distinctive vertical black stripes; the patterns of which are unique in each individual", 2, "Tiger" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogPosts_AuthorId",
                table: "blogPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPosts_TagId",
                table: "blogPosts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryTags_BlogPostId",
                table: "categoryTags",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPosts_categoryTags_TagId",
                table: "blogPosts",
                column: "TagId",
                principalTable: "categoryTags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPosts_authors_AuthorId",
                table: "blogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPosts_categoryTags_TagId",
                table: "blogPosts");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categoryTags");

            migrationBuilder.DropTable(
                name: "blogPosts");
        }
    }
}
