using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsPaymentData
    {
        private readonly AppDbContext _context;

        public clsPaymentData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(DateTime date, int amount, string additionalNotes, int paymentMethodsId)
        {
            var payment = new Payment
            {
                Date = date,
                Amount = amount,
                AdditionalNotes = string.IsNullOrWhiteSpace(additionalNotes) ? null : additionalNotes,
                PaymentMethodsId = paymentMethodsId
            };

            _context.Payment.Add(payment);
            _context.SaveChanges();
            return payment.Id;
        }

        public bool Update(int id, DateTime date, int amount, string additionalNotes, int paymentMethodsId)
        {
            var payment = _context.Payment.Find(id);
            if (payment == null) return false;

            payment.Date = date;
            payment.Amount = amount;
            payment.AdditionalNotes = string.IsNullOrWhiteSpace(additionalNotes) ? null : additionalNotes;
            payment.PaymentMethodsId = paymentMethodsId;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var payment = _context.Payment.Find(id);
            if (payment == null) return false;

            _context.Payment.Remove(payment);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(int id)
        {
            return _context.Payment.Any(p => p.Id == id);
        }

        public List<Payment> GetAll()
        {
            return _context.Payment.ToList();
        }

        public bool GetPayment(int id, out DateTime date, out int amount, out string additionalNotes, out int paymentMethodsId)
        {
            var payment = _context.Payment.Find(id);
            if (payment == null)
            {
                date = default;
                amount = 0;
                additionalNotes = string.Empty;
                paymentMethodsId = 0;
                return false;
            }

            date = payment.Date;
            amount = payment.Amount;
            additionalNotes = payment.AdditionalNotes ?? string.Empty;
            paymentMethodsId = payment.PaymentMethodsId;
            return true;
        }
    }
}
