namespace HospitalProject.Entities.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int AppointmentID { get; set; }
        public int MedicineID { get; set; }
        public int MedicineAmount { get; set; }

        public Appointment Appointment { get; set; }

        public Medicine Medicine { get; set; }
    }
}
