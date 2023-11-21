using HospitalProject.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Repositories.Config
{
    public class MedicineConfig : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m => m.MedicineID);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        }
    }

}
