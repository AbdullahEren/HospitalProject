using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.PatientID);
            builder.Property(p => p.FName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LName).IsRequired().HasMaxLength(50);
            builder.HasOne(p => p.FamilyDoctor)
                .WithMany()
                .HasForeignKey(p => p.FamilyDoctorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
