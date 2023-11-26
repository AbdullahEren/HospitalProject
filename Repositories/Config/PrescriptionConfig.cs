using HospitalProject.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Repositories.Config
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.PrescriptionID);
            builder.HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => p.AppointmentID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Medicine)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => p.MedicineID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
