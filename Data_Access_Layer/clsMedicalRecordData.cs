using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsMedicalRecordData
    {
        private readonly AppDbContext _context;

        public clsMedicalRecordData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public bool Update(MedicalRecord record)
        {
            var existing = _context.MedicalRecords.Find(record.Id);
            if (existing == null) return false;

            existing.VisitDescription = record.VisitDescription;
            existing.Diagnosis = record.Diagnosis;
            existing.AdditionalNotes = record.AdditionalNotes;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var record = _context.MedicalRecords.Find(id);
            if (record == null) return false;

            _context.MedicalRecords.Remove(record);
            _context.SaveChanges();
            return true;
        }

        public List<MedicalRecord> GetAll()
        {
            return _context.MedicalRecords.ToList();
        }

        public MedicalRecord? GetById(int id)
        {
            return _context.MedicalRecords.FirstOrDefault(r => r.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.MedicalRecords.Any(r => r.Id == id);
        }
    }
}
