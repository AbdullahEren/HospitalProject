using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IMedicineService
    {
        Task<MedicineDtoForRead> GetMedicineByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<MedicineDtoForRead>> GetAllMedicinesAsync(bool trackChanges);
        Task CreateMedicine(MedicineDtoForCreation medicine);
        Task UpdateMedicine(int id, MedicineDtoForUpdate medicine);
        Task DeleteMedicine(int id, bool trackChanges);
    }
}
