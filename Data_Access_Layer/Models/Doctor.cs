using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Column("SpecializationId")]
        public int MedicalSpecialtiesId { get; set; }
        public int EmployeeId { get; set; }
        public MedicalSpecialties MedicalSpecialties { get; set; }
        public Employee Employee { get; set; }
    }
}
