using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Data_Business_Layer_Clinic
{
    public class clsAppointmentStatus
    {
        private readonly clsAppointmentStatusData _data;

        public clsAppointmentStatus(clsAppointmentStatusData data)
        {
            _data = data;
        }

        public int Add(string name)
        {
            return _data.Add(name);
        }

        public bool Update(int id, string name)
        {
            return _data.Update(id, name);
        }

        public bool Delete(int id)
        {
            return _data.Delete(id);
        }

        public bool Exists(int id)
        {
            return _data.Exist(id);
        }

        public List<AppointmentStatus> GetAll()
        {
            return _data.All();
        }

        public bool TryGetAppointmentStatus(int id, out string name)
        {
            return _data.GetAppointmentStatus(id, out name);
        }

        public string GetNameById(int id)
        {
            return _data.GetNameById(id);
        }

        public int GetIdByName(string name)
        {
            return _data.GetIdByName(name);
        }
    }
}
