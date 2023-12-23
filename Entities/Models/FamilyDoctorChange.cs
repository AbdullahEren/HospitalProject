using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class FamilyDoctorChange
    {
        public int ChangeID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int OldFamilyDoctorID { get; set; }
        [Required]
        public int NewFamilyDoctorID { get; set; }
        [Required]
        public DateTime ChangeDate { get; set; } = DateTime.Now;

        public virtual Patient Patient { get; set; }

        public virtual Doctor OldFamilyDoctor { get; set; }

        public virtual Doctor NewFamilyDoctor { get; set; }
    }
}
