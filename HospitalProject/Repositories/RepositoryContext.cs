using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<FamilyDoctorChange> FamilyDoctorChanges { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfig());
            modelBuilder.ApplyConfiguration(new PatientConfig());
            modelBuilder.ApplyConfiguration(new MedicineConfig());
            modelBuilder.ApplyConfiguration(new AppointmentConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionConfig());
            modelBuilder.ApplyConfiguration(new FamilyDoctorChangeConfig());

        }
    }
}
