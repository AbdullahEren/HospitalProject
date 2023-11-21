using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task CreateDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(Doctor doctor);
    }
}
