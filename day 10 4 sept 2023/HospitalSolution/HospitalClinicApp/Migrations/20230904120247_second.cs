using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalClinicApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "+91464676679");

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Age", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 101, 20, "xyz@gmail.com", "Ramu", "+91845875487" },
                    { 102, 22, "aaa@gmail.com", "Somu", "++9154985465" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "1236541256");
        }
    }
}
