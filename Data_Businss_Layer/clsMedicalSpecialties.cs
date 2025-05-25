using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Business_Layer_Clinic
{
    public class clsMedicalSpecialtyBusiness
    {
        private readonly clsMedicalSpecialtyData _data;

        public clsMedicalSpecialtyBusiness(AppDbContext context)
        {
            _data = new clsMedicalSpecialtyData(context);
        }

        public int Add(string name)
        {
            var specialty = new MedicalSpecialties
            {
                Name = name
            };
            return _data.Add(specialty);
        }

        public bool Update(int id, string name)
        {
            var specialty = new MedicalSpecialties
            {
                Id = id,
                Name = name
            };
            return _data.Update(specialty);
        }

        public bool Delete(int id)
        {
            return _data.Delete(id);
        }

        public bool Exists(int id)
        {
            return _data.Exists(id);
        }

        public List<MedicalSpecialties> GetAll()
        {
            return _data.GetAll();
        }

        public MedicalSpecialties? GetById(int id)
        {
            return _data.GetById(id);
        }

        public string? GetNameById(int id)
        {
            return _data.GetNameById(id);
        }

        public int? GetIdByName(string name)
        {
            return _data.GetIdByName(name);
        }
    }
}
