using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
