using HospitalProject.Repositories;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services;
using HospitalProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("mssqlconnection"), b => b.MigrationsAssembly("HospitalProject"));
            });
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IFamilyDoctorChangeRepository, FamilyDoctorChangeRepository>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientManager>();
            services.AddScoped<IDoctorService, DoctorManager>();
            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IPrescriptionService, PrescriptionManager>();
            services.AddScoped<IMedicineService, MedicineManager>();
            services.AddScoped<IFamilyDoctorChangeService, FamilyDoctorChangeManager>();   
        }
    }
}
