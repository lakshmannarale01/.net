﻿// <auto-generated />
using System;
using DoctorsApplication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoctorsApplication.Migrations
{
    [DbContext(typeof(DoctorContexts))]
    partial class DoctorContextsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DoctorsApplication.Models.Appoitment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppointmentID"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DoctorId");

                    b.ToTable("appoitments");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DepartmentId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Doctors", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("DoctorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("doctor");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Patient", b =>
                {
                    b.Property<string>("IdentityNo")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AppointmentID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdentityNo");

                    b.HasIndex("AppointmentID")
                        .IsUnique();

                    b.HasIndex("DoctorId");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Appoitment", b =>
                {
                    b.HasOne("DoctorsApplication.Models.Department", "department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsApplication.Models.Doctors", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("department");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Doctors", b =>
                {
                    b.HasOne("DoctorsApplication.Models.Department", "Department")
                        .WithMany("doctor")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Patient", b =>
                {
                    b.HasOne("DoctorsApplication.Models.Appoitment", "appoitment")
                        .WithOne("Patient")
                        .HasForeignKey("DoctorsApplication.Models.Patient", "AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsApplication.Models.Doctors", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("appoitment");
                });

            modelBuilder.Entity("DoctorsApplication.Models.Appoitment", b =>
                {
                    b.Navigation("Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorsApplication.Models.Department", b =>
                {
                    b.Navigation("doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
