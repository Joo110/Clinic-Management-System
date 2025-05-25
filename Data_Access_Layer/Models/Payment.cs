using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string AdditionalNotes { get; set; }
        public int PaymentMethodsId { get; set; }
        //public PaymentMethods PaymentMethods { get; set; }
    }
}
