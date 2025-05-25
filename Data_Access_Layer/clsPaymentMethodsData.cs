using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsPaymentMethodsData
    {
        private readonly AppDbContext _context;

        public clsPaymentMethodsData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(string name)
        {
            var paymentMethod = new PaymentMethods { Name = name };
            _context.PaymentMethods.Add(paymentMethod);
            _context.SaveChanges();
            return paymentMethod.Id;
        }

        public bool Update(int id, string name)
        {
            var method = _context.PaymentMethods.Find(id);
            if (method == null)
                return false;

            method.Name = name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var method = _context.PaymentMethods.Find(id);
            if (method == null)
                return false;

            _context.PaymentMethods.Remove(method);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(int id)
        {
            return _context.PaymentMethods.Any(m => m.Id == id);
        }

        public List<PaymentMethods> All()
        {
            return _context.PaymentMethods.ToList();
        }

        public bool GetPaymentMethods(int id, out string name)
        {
            var method = _context.PaymentMethods.Find(id);
            if (method == null)
            {
                name = string.Empty;
                return false;
            }

            name = method.Name;
            return true;
        }

        public string GetNameById(int id)
        {
            var method = _context.PaymentMethods.Find(id);
            return method?.Name ?? string.Empty;
        }

        public int GetIdByName(string name)
        {
            var method = _context.PaymentMethods.FirstOrDefault(m => m.Name == name);
            return method?.Id ?? -1;
        }
    }
}
