using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record PrescriptionDtoForCreation
    {
        [Required]
        public int MedicineID { get; init; }
        [Required]
        public int MedicineAmount { get; init; }
    }
}
