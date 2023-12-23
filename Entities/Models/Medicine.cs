using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
