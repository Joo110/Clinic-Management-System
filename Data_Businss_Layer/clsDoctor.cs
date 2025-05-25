using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;

namespace Data_Business_Layer_Clinic
{
    public class clsDoctor
    {
        private readonly clsDoctorData _repo;

        public clsDoctor(clsDoctorData repo)
        {
            _repo = repo;
        }

        public int AddDoctor(int medicalSpecialtiesId, int employeeId)
        {
            var doctor = new Doctor
            {
                MedicalSpecialtiesId = medicalSpecialtiesId,
                EmployeeId = employeeId
            };

            return _repo.Add(doctor);
        }

        public bool UpdateDoctor(int id, int medicalSpecialtiesId, int employeeId)
        {
            var doctor = new Doctor
            {
                Id = id,
                MedicalSpecialtiesId = medicalSpecialtiesId,
                EmployeeId = employeeId
            };

            return _repo.Update(doctor);
        }

        public bool DeleteDoctor(int id) => _repo.Delete(id);

        public Doctor? GetDoctor(int id) => _repo.GetById(id);

        public List<Doctor> GetAllDoctors() => _repo.GetAll();

        public bool DoctorExists(int id) => _repo.Exists(id);

        public int? GetDoctorIdByEmployeeId(int employeeId) => _repo.GetIdByEmployeeId(employeeId);

        public int? GetEmployeeIdByDoctorId(int doctorId) => _repo.GetEmployeeIdByDoctorId(doctorId);
    }
}
