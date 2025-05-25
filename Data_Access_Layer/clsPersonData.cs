using System;
using System.Linq;
using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;

namespace Data_Access_Layer_Clinic
{
    public class clsPersonData
    {
        private readonly AppDbContext _context;

        public clsPersonData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

        public bool Update(Person person)
        {
            var existing = _context.Persons.Find(person.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(person);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var person = _context.Persons.Find(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            return _context.SaveChanges() > 0;
        }

        public Person? GetById(int id)
        {
            return _context.Persons.Find(id);
        }

        public int? GetIdByName(string name)
        {
            return _context.Persons
                .Where(p => p.Name == name)
                .Select(p => (int?)p.Id)
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
