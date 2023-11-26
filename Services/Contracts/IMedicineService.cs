using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IMedicineService
    {
        Task<MedicineDtoForRead> GetMedicineByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<MedicineDtoForRead>> GetAllMedicinesAsync(bool trackChanges);
        Task CreateMedicine(MedicineDtoForCreation medicineDto);
        Task UpdateMedicine(int id, MedicineDtoForUpdate medicineDto);
        Task DeleteMedicine(int id, bool trackChanges);
    }
}
