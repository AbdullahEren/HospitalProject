using HospitalProject.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Repositories.Config
{
    public class FamilyDoctorChangeConfig : IEntityTypeConfiguration<FamilyDoctorChange>
    {
        public void Configure(EntityTypeBuilder<FamilyDoctorChange> builder)
        {
            builder.HasKey(f => f.ChangeID);
            builder.Property(f => f.ChangeDate).IsRequired();
            builder.HasOne(f => f.Patient)
                .WithMany()
                .HasForeignKey(f => f.PatientID);
            builder.HasOne(f => f.OldFamilyDoctor)
                .WithMany()
                .HasForeignKey(f => f.OldFamilyDoctorID);
            builder.HasOne(f => f.NewFamilyDoctor)
                .WithMany()
                .HasForeignKey(f => f.NewFamilyDoctorID);
        }
    }

}
