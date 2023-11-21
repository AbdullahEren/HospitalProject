﻿// <auto-generated />
using System;
using HospitalProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalProject.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospitalProject.Entities.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"), 1L, 1);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<bool>("IsFamilyDoctorAppointment")
                        .HasColumnType("bit");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"), 1L, 1);

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.FamilyDoctorChange", b =>
                {
                    b.Property<int>("ChangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChangeID"), 1L, 1);

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewFamilyDoctorID")
                        .HasColumnType("int");

                    b.Property<int>("OldFamilyDoctorID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ChangeID");

                    b.HasIndex("NewFamilyDoctorID");

                    b.HasIndex("OldFamilyDoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("FamilyDoctorChanges");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicineID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MedicineID");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"), 1L, 1);

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FamilyDoctorID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PatientID");

                    b.HasIndex("FamilyDoctorID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescriptionID"), 1L, 1);

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<int>("MedicineAmount")
                        .HasColumnType("int");

                    b.Property<int>("MedicineID")
                        .HasColumnType("int");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("AppointmentID");

                    b.HasIndex("MedicineID");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Appointment", b =>
                {
                    b.HasOne("HospitalProject.Entities.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HospitalProject.Entities.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.FamilyDoctorChange", b =>
                {
                    b.HasOne("HospitalProject.Entities.Models.Doctor", "NewFamilyDoctor")
                        .WithMany()
                        .HasForeignKey("NewFamilyDoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HospitalProject.Entities.Models.Doctor", "OldFamilyDoctor")
                        .WithMany()
                        .HasForeignKey("OldFamilyDoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HospitalProject.Entities.Models.Patient", "Patient")
                        .WithMany("FamilyDoctorChanges")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewFamilyDoctor");

                    b.Navigation("OldFamilyDoctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Patient", b =>
                {
                    b.HasOne("HospitalProject.Entities.Models.Doctor", "FamilyDoctor")
                        .WithMany()
                        .HasForeignKey("FamilyDoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FamilyDoctor");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Prescription", b =>
                {
                    b.HasOne("HospitalProject.Entities.Models.Appointment", "Appointment")
                        .WithMany("Prescriptions")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HospitalProject.Entities.Models.Medicine", "Medicine")
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Appointment", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Medicine", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("HospitalProject.Entities.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("FamilyDoctorChanges");
                });
#pragma warning restore 612, 618
        }
    }
}
