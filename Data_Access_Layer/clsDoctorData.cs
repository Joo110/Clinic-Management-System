using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsDoctorData
    {
        private readonly AppDbContext _context;

        public clsDoctorData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor.Id;
        }

        public bool Update(Doctor doctor)
        {
            var existing = _context.Doctors.Find(doctor.Id);
            if (existing == null) return false;

            existing.EmployeeId = doctor.EmployeeId;
            existing.MedicalSpecialtiesId = doctor.MedicalSpecialtiesId;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return true;
        }

        public Doctor? GetById(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public bool Exists(int id)
        {
            return _context.Doctors.Any(d => d.Id == id);
        }

        public int? GetIdByEmployeeId(int employeeId)
        {
            return _context.Doctors
                .Where(d => d.EmployeeId == employeeId)
                .Select(d => d.Id)
                .FirstOrDefault();
        }

        public int? GetEmployeeIdByDoctorId(int doctorId)
        {
            return _context.Doctors
                .Where(d => d.Id == doctorId)
                .Select(d => d.EmployeeId)
                .FirstOrDefault();
        }
    }
}
