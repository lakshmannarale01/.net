using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XYZHotels.Migrations
{
    public partial class pic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "rooms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "hotel",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pic",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "Pic",
                table: "hotel");
        }
    }
}
