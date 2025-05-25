using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsCountryData
    {
        private readonly AppDbContext _context;

        public clsCountryData(AppDbContext context)
        {
            _context = context;
        }

        public List<Countries> All()
        {
            return _context.Countries.ToList();
        }

        public int GetIdByName(string name)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Name == name);
            return country?.Id ?? -1;
        }

        public string GetNameById(int id)
        {
            var country = _context.Countries.Find(id);
            return country?.Name ?? string.Empty;
        }
    }
}
