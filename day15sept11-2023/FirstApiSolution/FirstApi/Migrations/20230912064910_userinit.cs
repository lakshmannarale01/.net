using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApi.Migrations
{
    public partial class userinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "employees",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "employees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    Key = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Username);
                });

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "IsActive",
                value: null);

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 102,
                column: "IsActive",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_employees_Username",
                table: "employees",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_Username",
                table: "employees",
                column: "Username",
                principalTable: "users",
                principalColumn: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_Username",
                table: "employees");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_employees_Username",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "employees");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "employees",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 102,
                column: "IsActive",
                value: false);
        }
    }
}
