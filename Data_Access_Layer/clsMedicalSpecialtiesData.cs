using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsMedicalSpecialtyData
    {
        private readonly AppDbContext _context;

        public clsMedicalSpecialtyData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(MedicalSpecialties specialty)
        {
            _context.MedicalSpecialties.Add(specialty);
            _context.SaveChanges();
            return specialty.Id;
        }

        public bool Update(MedicalSpecialties specialty)
        {
            var existing = _context.MedicalSpecialties.Find(specialty.Id);
            if (existing == null) return false;

            existing.Name = specialty.Name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var specialty = _context.MedicalSpecialties.Find(id);
            if (specialty == null) return false;

            _context.MedicalSpecialties.Remove(specialty);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.MedicalSpecialties.Any(s => s.Id == id);
        }

        public List<MedicalSpecialties> GetAll()
        {
            return _context.MedicalSpecialties.ToList();
        }

        public MedicalSpecialties? GetById(int id)
        {
            return _context.MedicalSpecialties.FirstOrDefault(s => s.Id == id);
        }

        public string? GetNameById(int id)
        {
            return _context.MedicalSpecialties
                .Where(s => s.Id == id)
                .Select(s => s.Name)
                .FirstOrDefault();
        }

        public int? GetIdByName(string name)
        {
            return _context.MedicalSpecialties
                .Where(s => s.Name == name)
                .Select(s => s.Id)
                .FirstOrDefault();
        }
    }
}
