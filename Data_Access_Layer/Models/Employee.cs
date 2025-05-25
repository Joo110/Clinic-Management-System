using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public int PersonId { get; set; }//Fk
        public int CareerId { get; set; }//FK
        public Person Person { get; private set; }//composite
        public CareerSpecialization Career { get; set; }
    }
}
