using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;

namespace Data_Business_Layer_Clinic
{
    public class clsPerson
    {
        private readonly clsPersonData _repo;

        public clsPerson(clsPersonData repo)
        {
            _repo = repo;
        }

        public int AddPerson(string name, DateTime birthDate, string gender, string phone, string email, int countryId, string address, string imagePath)
        {
            var person = new Person
            {
                Name = name,
                BirthDate = birthDate,
                Gender = gender,
                Phone = phone,
                Email = email,
                CountryId = countryId,
                Address = address,
                ImagePath = string.IsNullOrWhiteSpace(imagePath) ? null : imagePath
            };

            return _repo.Add(person);
        }

        public bool UpdatePerson(int id, string name, DateTime birthDate, string gender, string phone, string email, int countryId, string address, string imagePath)
        {
            var person = new Person
            {
                Id = id,
                Name = name,
                BirthDate = birthDate,
                Gender = gender,
                Phone = phone,
                Email = email,
                CountryId = countryId,
                Address = address,
                ImagePath = string.IsNullOrWhiteSpace(imagePath) ? null : imagePath
            };

            return _repo.Update(person);
        }

        public bool DeletePerson(int id) => _repo.Delete(id);

        public Person? GetPerson(int id) => _repo.GetById(id);

        public int? GetPersonIdByName(string name) => _repo.GetIdByName(name);

        public bool PersonExists(int id) => _repo.Exists(id);
    }
}
