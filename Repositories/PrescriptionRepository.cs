using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class PrescriptionRepository : RepositoryBase<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePrescription(Prescription prescription) =>
            await CreateAsync(prescription);

        public async Task DeletePrescription(Prescription prescription) =>
            await DeleteAsync(prescription);

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync(bool trackChanges) =>
            await FindAllAsync(trackChanges);

        public async Task<IEnumerable<Prescription>> GetPrescriptionByAppointmentIdAsync(int id, bool trackChanges)
        {
            var prescription = await FindByConditionAsync(p => p.AppointmentID.Equals(id), trackChanges);
            return prescription;
        }
    }
}
