using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer_Clinic
{
    public class clsEmployeeData
    {
        private readonly AppDbContext _context;

        public clsEmployeeData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }

        public bool Update(Employee employee)
        {
            var existing = _context.Employees.Find(employee.Id);
            if (existing == null) return false;

            existing.Salary = employee.Salary;
            existing.CareerId = employee.CareerId;
            existing.PersonId = employee.PersonId;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public int? GetPersonIdByEmployeeId(int id)
        {
            return _context.Employees
                .Where(e => e.Id == id)
                .Select(e => e.PersonId)
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
