using HospitalProject.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Repositories.Config
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorID);
            builder.Property(d => d.FName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LName).IsRequired().HasMaxLength(50);
        }
    }

}
