using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        Task<Doctor> GetDoctorByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges);
        Task CreateDoctor(Doctor doctor);
        Task UpdateDoctor(int id,Doctor doctor);
        Task DeleteDoctor(Doctor doctor);
    }
}
