﻿namespace HospitalProject.Entities.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsFamilyDoctorAppointment { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
