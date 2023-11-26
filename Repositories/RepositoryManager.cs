using HospitalProject.Repositories.Contracts;

namespace HospitalProject.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;

        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        private Lazy<IPrescriptionRepository> _prescriptionRepository;
        private Lazy<IMedicineRepository> _medicineRepository;
        private Lazy<IFamilyDoctorChangeRepository> _familyDoctorChangeRepository;

        public RepositoryManager(RepositoryContext repositoryContext, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            _context = repositoryContext;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            
            _prescriptionRepository = new Lazy<IPrescriptionRepository>(() => new PrescriptionRepository(_context));
            _medicineRepository = new Lazy<IMedicineRepository>(() => new MedicineRepository(_context));
            _familyDoctorChangeRepository = new Lazy<IFamilyDoctorChangeRepository>(() => new FamilyDoctorChangeRepository(_context));
        }

        public IPatientRepository Patient => _patientRepository;
        public IDoctorRepository Doctor => _doctorRepository;
        public IAppointmentRepository Appointment => _appointmentRepository;
        public IPrescriptionRepository Prescription => _prescriptionRepository.Value;
        public IMedicineRepository Medicine => _medicineRepository.Value;
        public IFamilyDoctorChangeRepository FamilyDoctorChange => _familyDoctorChangeRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
