using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic
{
    public class clsPatientData
    {
        private readonly AppDbContext _context;

        public clsPatientData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(int personId)
        {
            var patient = new Patient { PersonId = personId };
            _context.Patient.Add(patient);
            _context.SaveChanges();
            return patient.Id;
        }

        public bool Update(int id, int personId)
        {
            var patient = _context.Patient.Find(id);
            if (patient == null) return false;

            patient.PersonId = personId;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var patient = _context.Patient.Find(id);
            if (patient == null) return false;

            _context.Patient.Remove(patient);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(int id)
        {
            return _context.Patient.Any(p => p.Id == id);
        }

        public List<Patient> GetAll()
        {
            return _context.Patient.ToList();
        }

        public bool GetPatient(int id, out int personId)
        {
            var patient = _context.Patient.Find(id);
            if (patient == null)
            {
                personId = 0;
                return false;
            }

            personId = patient.PersonId;
            return true;
        }

        public int GetPersonIdByPatientId(int patientId)
        {
            return _context.Patient
                           .Where(p => p.Id == patientId)
                           .Select(p => p.PersonId)
                           .FirstOrDefault();
        }
    }
}
