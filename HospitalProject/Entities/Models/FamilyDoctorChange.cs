using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Models
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

        public Patient Patient { get; set; }

        public Doctor OldFamilyDoctor { get; set; }

        public Doctor NewFamilyDoctor { get; set; }
    }
}
