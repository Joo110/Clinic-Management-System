using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Business_Layer_Clinic
{
    public class clsPaymentMethods
    {
        private readonly clsPaymentMethodsData _dataAccess;

        public clsPaymentMethods(clsPaymentMethodsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int AddPaymentMethod(string name)
        {
            return _dataAccess.Add(name);
        }

        public bool UpdatePaymentMethod(int id, string name)
        {
            return _dataAccess.Update(id, name);
        }

        public bool DeletePaymentMethod(int id)
        {
            return _dataAccess.Delete(id);
        }

        public bool PaymentMethodExists(int id)
        {
            return _dataAccess.Exist(id);
        }

        public List<PaymentMethods> GetAllPaymentMethods()
        {
            return _dataAccess.All();
        }

        public bool TryGetPaymentMethod(int id, out string name)
        {
            return _dataAccess.GetPaymentMethods(id, out name);
        }

        public string GetNameById(int id)
        {
            return _dataAccess.GetNameById(id);
        }

        public int GetIdByName(string name)
        {
            return _dataAccess.GetIdByName(name);
        }
    }
}
