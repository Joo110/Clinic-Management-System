using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Column("DateTime")]
        public DateTime? Date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentStatusId { get; set; }
        public int PaymentId { get; set; }
        public int MedicalRecordId { get; set; }
        //public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        //public Payment Payment { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
