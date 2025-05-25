using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsAppointmentStatusData
    {
        private readonly AppDbContext _context;

        public clsAppointmentStatusData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(string name)
        {
            var status = new AppointmentStatus { Name = name };
            _context.AppointmentStatuses.Add(status);
            _context.SaveChanges();
            return status.Id;
        }

        public bool Update(int id, string name)
        {
            var status = _context.AppointmentStatuses.Find(id);
            if (status == null)
                return false;

            status.Name = name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var status = _context.AppointmentStatuses.Find(id);
            if (status == null)
                return false;

            _context.AppointmentStatuses.Remove(status);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(int id)
        {
            return _context.AppointmentStatuses.Any(s => s.Id == id);
        }

        public List<AppointmentStatus> All()
        {
            return _context.AppointmentStatuses.ToList();
        }

        public bool GetAppointmentStatus(int id, out string name)
        {
            name = null;
            var status = _context.AppointmentStatuses.Find(id);
            if (status == null)
                return false;

            name = status.Name;
            return true;
        }

        public string GetNameById(int id)
        {
            var status = _context.AppointmentStatuses.Find(id);
            return status?.Name;
        }

        public int GetIdByName(string name)
        {
            var status = _context.AppointmentStatuses.FirstOrDefault(s => s.Name == name);
            return status?.Id ?? -1;
        }
    }
}
