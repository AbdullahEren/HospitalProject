using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;

namespace HospitalProject.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateDoctor(Doctor doctor) => await CreateAsync(doctor);

        public async Task DeleteDoctor(Doctor doctor) => await DeleteAsync(doctor);

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges) => await FindAllAsync(trackChanges);

        public async Task<Doctor> GetDoctorByIdAsync(int id, bool trackChanges)
        {
            var doctor = await FindByConditionAsync(p => p.DoctorID.Equals(id), trackChanges);
            return doctor.SingleOrDefault();
        }

        public async Task UpdateDoctor(int id,Doctor doctor)
        {
            doctor.DoctorID = id;
            await UpdateAsync(doctor);
        }
    }
}
