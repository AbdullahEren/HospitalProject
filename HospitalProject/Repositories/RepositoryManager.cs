using HospitalProject.Repositories.Contracts;
using HospitalProject.Repositories;

namespace HospitalProject.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;
        private Lazy<IPatientRepository> _patientRepository;
        private Lazy<IDoctorRepository> _doctorRepository;
        private Lazy<IAppointmentRepository> _appointmentRepository;
        private Lazy<IPrescriptionRepository> _prescriptionRepository;
        private Lazy<IMedicineRepository> _medicineRepository;
        private Lazy<IFamilyDoctorChangeRepository> _familyDoctorChangeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(_context));
            _doctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(_context));
            _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(_context));
            _prescriptionRepository = new Lazy<IPrescriptionRepository>(() => new PrescriptionRepository(_context));
            _medicineRepository = new Lazy<IMedicineRepository>(() => new MedicineRepository(_context));
            _familyDoctorChangeRepository = new Lazy<IFamilyDoctorChangeRepository>(() => new FamilyDoctorChangeRepository(_context));
        }

        public IPatientRepository Patient => _patientRepository.Value;
        public IDoctorRepository Doctor => _doctorRepository.Value;
        public IAppointmentRepository Appointment => _appointmentRepository.Value;
        public IPrescriptionRepository Prescription => _prescriptionRepository.Value;
        public IMedicineRepository Medicine => _medicineRepository.Value;
        public IFamilyDoctorChangeRepository FamilyDoctorChange => _familyDoctorChangeRepository.Value;
        
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}