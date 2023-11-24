using HospitalProject.Repositories;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services;
using HospitalProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mssqlconnection"), b => b.MigrationsAssembly("HospitalProject"));

});

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IFamilyDoctorChangeRepository, FamilyDoctorChangeRepository>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddScoped<IPatientService, PatientManager>();
builder.Services.AddScoped<IDoctorService, DoctorManager>();
builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionManager>();
builder.Services.AddScoped<IMedicineService, MedicineManager>();
builder.Services.AddScoped<IFamilyDoctorChangeService, FamilyDoctorChangeManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
