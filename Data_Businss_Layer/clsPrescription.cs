using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Business_Layer_Clinic
{
    public class clsPrescription
    {
        private readonly clsPrescriptionData _repository;

        public clsPrescription(clsPrescriptionData repository)
        {
            _repository = repository;
        }

        public int AddPrescription(Prescriptions prescription)
        {
            return _repository.Add(prescription);
        }

        public bool UpdatePrescription(Prescriptions prescription)
        {
            return _repository.Update(prescription);
        }

        public bool DeletePrescription(int id)
        {
            return _repository.Delete(id);
        }

        public bool PrescriptionExists(int id)
        {
            return _repository.Exist(id);
        }

        public List<Prescriptions> GetAllPrescriptions()
        {
            return _repository.All();
        }

        public Prescriptions GetPrescriptionById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
