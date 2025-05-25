using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsCareerData
    {
        private readonly AppDbContext _context;

        public clsCareerData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(CareerSpecialization career)
        {
            _context.CareerSpecializations.Add(career);
            _context.SaveChanges();
            return career.Id;
        }

        public bool Update(CareerSpecialization career)
        {
            _context.CareerSpecializations.Update(career);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var career = _context.CareerSpecializations.Find(id);
            if (career == null) return false;

            _context.CareerSpecializations.Remove(career);
            return _context.SaveChanges() > 0;
        }

        public CareerSpecialization GetById(int id)
        {
            return _context.CareerSpecializations.FirstOrDefault(c => c.Id == id);
        }

        public List<CareerSpecialization> GetAll()
        {
            return _context.CareerSpecializations.ToList();
        }

        public bool Exists(int id)
        {
            return _context.CareerSpecializations.Any(c => c.Id == id);
        }

        public int GetIdByName(string name)
        {
            var career = _context.CareerSpecializations.FirstOrDefault(c => c.Name == name);
            return career?.Id ?? -1;
        }

        public string GetNameById(int id)
        {
            var career = _context.CareerSpecializations.FirstOrDefault(c => c.Id == id);
            return career?.Name;
        }
    }
}
