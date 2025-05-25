using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Business_Layer_Clinic
{
    public class clsCountry
    {
        private readonly clsCountryData _countryData;

        public clsCountry(clsCountryData countryData)
        {
            _countryData = countryData;
        }

        public List<Countries> GetAllCountries()
        {
            return _countryData.All();
        }

        public int GetCountryIdByName(string name)
        {
            return _countryData.GetIdByName(name);
        }

        public string GetCountryNameById(int id)
        {
            return _countryData.GetNameById(id);
        }
    }
}
