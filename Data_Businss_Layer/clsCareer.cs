using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace ClinicSystemBusiness
{
    public class clsCareer
    {
        private readonly clsCareerData _repository;

        public clsCareer(AppDbContext context)
        {
            _repository = new clsCareerData(context);
        }

        public int AddCareer(string name)
        {
            var career = new CareerSpecialization { Name = name };
            return _repository.Add(career);
        }

        public bool UpdateCareer(int id, string name)
        {
            var career = _repository.GetById(id);
            if (career == null) return false;

            career.Name = name;
            return _repository.Update(career);
        }

        public bool DeleteCareer(int id)
        {
            return _repository.Delete(id);
        }

        public CareerSpecialization GetCareerById(int id)
        {
            return _repository.GetById(id);
        }

        public List<CareerSpecialization> GetAllCareers()
        {
            return _repository.GetAll();
        }

        public bool CareerExists(int id)
        {
            return _repository.Exists(id);
        }

        public int GetCareerIdByName(string name)
        {
            return _repository.GetIdByName(name);
        }

        public string GetCareerNameById(int id)
        {
            return _repository.GetNameById(id);
        }
    }
}
