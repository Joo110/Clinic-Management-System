using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Business_Layer_Clinic
{
    public class MedicalRecordService
    {
        private readonly clsMedicalRecordData _data;

        public MedicalRecordService(clsMedicalRecordData data)
        {
            _data = data;
        }

        public int AddMedicalRecord(string visitDescription, string diagnosis, string? additionalNotes)
        {
            var record = new MedicalRecord
            {
                VisitDescription = visitDescription,
                Diagnosis = diagnosis,
                AdditionalNotes = additionalNotes
            };

            return _data.Add(record);
        }

        public bool UpdateMedicalRecord(int id, string visitDescription, string diagnosis, string? additionalNotes)
        {
            var record = new MedicalRecord
            {
                Id = id,
                VisitDescription = visitDescription,
                Diagnosis = diagnosis,
                AdditionalNotes = additionalNotes
            };

            return _data.Update(record);
        }

        public bool DeleteMedicalRecord(int id)
        {
            return _data.Delete(id);
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return _data.GetAll();
        }

        public MedicalRecord? GetMedicalRecordById(int id)
        {
            return _data.GetById(id);
        }

        public bool MedicalRecordExists(int id)
        {
            return _data.Exists(id);
        }
    }
}
