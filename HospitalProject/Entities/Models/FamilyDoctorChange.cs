namespace HospitalProject.Entities.Models
{
    public class FamilyDoctorChange
    {
        public int ChangeID { get; set; }
        public int PatientID { get; set; }
        public int OldFamilyDoctorID { get; set; }
        public int NewFamilyDoctorID { get; set; }
        public DateTime ChangeDate { get; set; }

        public Patient Patient { get; set; }

        public Doctor OldFamilyDoctor { get; set; }

        public Doctor NewFamilyDoctor { get; set; }
    }
}
