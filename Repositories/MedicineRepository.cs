using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateMedicine(Medicine medicine) => await CreateAsync(medicine);

        public async Task DeleteMedicine(Medicine medicine) => await DeleteAsync(medicine);

        public async Task<IEnumerable<Medicine>> GetAllMedicinesAsync(bool trackChanges) => await FindAllAsync(trackChanges);

        public async Task<Medicine> GetMedicineByIdAsync(int id, bool trackChanges)
        {
            var medicine = await FindByConditionAsync(p => p.MedicineID.Equals(id), trackChanges);
            return medicine.SingleOrDefault();
        }

        public async Task UpdateMedicine(int id,Medicine medicine)
        {
            medicine.MedicineID = id;
            await UpdateAsync(medicine);
        }
    }
}
