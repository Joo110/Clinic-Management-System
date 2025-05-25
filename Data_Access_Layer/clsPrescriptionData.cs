using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsPrescriptionData
    {
        private readonly AppDbContext _context;

        public clsPrescriptionData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Prescriptions prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
            return prescription.Id;
        }

        public bool Update(Prescriptions updatedPrescription)
        {
            var prescription = _context.Prescriptions.Find(updatedPrescription.Id);
            if (prescription == null) return false;

            prescription.Dosage = updatedPrescription.Dosage;
            prescription.Frequency = updatedPrescription.Frequency;
            prescription.StartDate = updatedPrescription.StartDate;
            prescription.EndDate = updatedPrescription.EndDate;
            prescription.SpecialInstructions = updatedPrescription.SpecialInstructions;
            prescription.MedicationName = updatedPrescription.MedicationName;
            prescription.MedicalRecordId = updatedPrescription.MedicalRecordId;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            if (prescription == null) return false;

            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(int id)
        {
            return _context.Prescriptions.Any(p => p.Id == id);
        }

        public List<Prescriptions> All()
        {
            return _context.Prescriptions.ToList();
        }

        public Prescriptions GetById(int id)
        {
            return _context.Prescriptions.Find(id);
        }
    }
}
