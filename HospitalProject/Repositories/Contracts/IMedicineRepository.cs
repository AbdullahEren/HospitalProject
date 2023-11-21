using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IMedicineRepository : IRepositoryBase<Medicine>
    {
        Task<Medicine> GetMedicineByIdAsync(int id);
        Task<IEnumerable<Medicine>> GetAllMedicinesAsync();
        Task CreateMedicine(Medicine medicine);
        Task UpdateMedicine(Medicine medicine);
        Task DeleteMedicine(Medicine medicine);
    }
}
