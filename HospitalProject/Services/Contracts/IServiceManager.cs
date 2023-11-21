namespace HospitalProject.Services.Contracts
{
    public interface IServiceManager
    {
        IPatientService Patient { get; }
        IDoctorService Doctor { get; }
        IMedicineService Medicine { get; }
        IAppointmentService Appointment { get; }
        IPrescriptionService Prescription { get; }
        IFamilyDoctorChangeService FamilyDoctorChange { get; }

    }
}
