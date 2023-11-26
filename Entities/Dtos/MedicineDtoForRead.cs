using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record MedicineDtoForRead
    {
        [Required]
        public int MedicineID { get; init; }
        [Required]
        public string Name { get; init; }
    }
}
