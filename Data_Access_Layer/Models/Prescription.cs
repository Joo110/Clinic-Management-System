using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic.Models
{
    public class Prescriptions
    {
        public int Id { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SpecialInstructions { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; private set; }
    }
}
