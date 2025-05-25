using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System.Collections.Generic;

namespace Data_Business_Layer_Clinic
{
    public class clsEmployee
    {
        private readonly clsEmployeeData _employeeData;

        public clsEmployee(clsEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public int Add(int salary, int careerId, int personId)
        {
            var employee = new Employee
            {
                Salary = salary,
                CareerId = careerId,
                PersonId = personId
            };
            return _employeeData.Add(employee);
        }

        public bool Update(int id, int salary, int careerId, int personId)
        {
            var employee = new Employee
            {
                Id = id,
                Salary = salary,
                CareerId = careerId,
                PersonId = personId
            };
            return _employeeData.Update(employee);
        }

        public bool Delete(int id)
        {
            return _employeeData.Delete(id);
        }

        public List<Employee> GetAll()
        {
            return _employeeData.GetAll();
        }

        public Employee? GetById(int id)
        {
            return _employeeData.GetById(id);
        }

        public int? GetPersonIdByEmployeeId(int employeeId)
        {
            return _employeeData.GetPersonIdByEmployeeId(employeeId);
        }

        public bool Exists(int id)
        {
            return _employeeData.Exists(id);
        }
    }
}
