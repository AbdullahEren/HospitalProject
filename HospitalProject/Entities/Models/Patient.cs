using System.Numerics;

namespace HospitalProject.Entities.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public int? FamilyDoctorID { get; set; }

        public Doctor FamilyDoctor { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<FamilyDoctorChange> FamilyDoctorChanges { get; set; }
    }
}
