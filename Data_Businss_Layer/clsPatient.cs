using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Business_Layer_Clinic
{
    public class clsPatient
    {
        private readonly clsPatientData _patientData;

        public clsPatient(clsPatientData patientData)
        {
            _patientData = patientData;
        }

        public int AddPatient(int personId)
        {
            return _patientData.Add(personId);
        }

        public bool UpdatePatient(int id, int personId)
        {
            return _patientData.Update(id, personId);
        }

        public bool DeletePatient(int id)
        {
            return _patientData.Delete(id);
        }

        public bool IsPatientExists(int id)
        {
            return _patientData.Exist(id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patientData.GetAll();
        }

        public bool TryGetPatient(int id, out int personId)
        {
            return _patientData.GetPatient(id, out personId);
        }

        public int GetPersonIdByPatientId(int patientId)
        {
            return _patientData.GetPersonIdByPatientId(patientId);
        }
    }
}
