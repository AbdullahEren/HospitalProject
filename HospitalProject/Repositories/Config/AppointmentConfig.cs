﻿using HospitalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalProject.Repositories.Config
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.AppointmentID);
            builder.Property(a => a.AppointmentDate).IsRequired();
            builder.HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientID);
            builder.HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorID);
        }
    }
}