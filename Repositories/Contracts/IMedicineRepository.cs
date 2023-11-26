using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IMedicineRepository : IRepositoryBase<Medicine>
    {
        Task<Medicine> GetMedicineByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Medicine>> GetAllMedicinesAsync(bool trackChanges);
        Task CreateMedicine(Medicine medicine);
        Task UpdateMedicine(int id,Medicine medicine);
        Task DeleteMedicine(Medicine medicine);
    }
}
