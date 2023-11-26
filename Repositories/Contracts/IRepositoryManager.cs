namespace HospitalProject.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IPatientRepository Patient { get; }
        IDoctorRepository Doctor { get; }
        IAppointmentRepository Appointment { get; }
        IMedicineRepository Medicine { get; }
        IFamilyDoctorChangeRepository FamilyDoctorChange { get; }
        IPrescriptionRepository Prescription { get; }
        Task SaveAsync();
    }
}
