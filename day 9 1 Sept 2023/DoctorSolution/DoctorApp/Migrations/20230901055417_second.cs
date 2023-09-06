using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentDoctorId",
                table: "patients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentPatientId",
                table: "patients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentDoctorId",
                table: "doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentPatientId",
                table: "doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_patients_AppointmentDoctorId_AppointmentPatientId",
                table: "patients",
                columns: new[] { "AppointmentDoctorId", "AppointmentPatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_doctors_AppointmentDoctorId_AppointmentPatientId",
                table: "doctors",
                columns: new[] { "AppointmentDoctorId", "AppointmentPatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_appointments_AppointmentDoctorId_AppointmentPatient~",
                table: "doctors",
                columns: new[] { "AppointmentDoctorId", "AppointmentPatientId" },
                principalTable: "appointments",
                principalColumns: new[] { "DoctorId", "PatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_patients_appointments_AppointmentDoctorId_AppointmentPatien~",
                table: "patients",
                columns: new[] { "AppointmentDoctorId", "AppointmentPatientId" },
                principalTable: "appointments",
                principalColumns: new[] { "DoctorId", "PatientId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_appointments_AppointmentDoctorId_AppointmentPatient~",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_appointments_AppointmentDoctorId_AppointmentPatien~",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_AppointmentDoctorId_AppointmentPatientId",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_doctors_AppointmentDoctorId_AppointmentPatientId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "AppointmentDoctorId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "AppointmentPatientId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "AppointmentDoctorId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "AppointmentPatientId",
                table: "doctors");
        }
    }
}
