using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;

namespace Business_Logic_Layer_Clinic
{
    public class clsPayment
    {
        private readonly clsPaymentData _paymentData;

        public clsPayment(clsPaymentData paymentData)
        {
            _paymentData = paymentData;
        }

        public int AddPayment(DateTime date, int amount, string notes, int methodId)
        {
            return _paymentData.Add(date, amount, notes, methodId);
        }

        public bool UpdatePayment(int id, DateTime date, int amount, string notes, int methodId)
        {
            return _paymentData.Update(id, date, amount, notes, methodId);
        }

        public bool DeletePayment(int id)
        {
            return _paymentData.Delete(id);
        }

        public bool PaymentExists(int id)
        {
            return _paymentData.Exist(id);
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentData.GetAll();
        }

        public bool GetPaymentDetails(int id, out DateTime date, out int amount, out string notes, out int methodId)
        {
            return _paymentData.GetPayment(id, out date, out amount, out notes, out methodId);
        }
    }
}
