using Data_Access_Layer_Clinic;
using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicSystemBusiness
{
    public class clsAppointment
    {
        private readonly clsAppointmentData _repository;

        public clsAppointment(AppDbContext context)
        {
            _repository = new clsAppointmentData(context);
        }

        public int AddAppointment(DateTime? date, int patientId, int doctorId, int appointmentStatusId, int paymentId, int medicalRecordId)
        {
            var appointment = new Appointment
            {
                Date = date,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentStatusId = appointmentStatusId,
                PaymentId = paymentId,
                MedicalRecordId = medicalRecordId
            };

            return _repository.Add(appointment);
        }

        public bool UpdateAppointment(int id, DateTime? date, int patientId, int doctorId, int appointmentStatusId, int paymentId, int medicalRecordId)
        {
            var appointment = _repository.GetById(id);
            if (appointment == null) return false;

            appointment.Date = date;
            appointment.PatientId = patientId;
            appointment.DoctorId = doctorId;
            appointment.AppointmentStatusId = appointmentStatusId;
            appointment.PaymentId = paymentId;
            appointment.MedicalRecordId = medicalRecordId;

            return _repository.Update(appointment);
        }

        public bool DeleteAppointment(int id)
        {
            return _repository.Delete(id);
        }

        public Appointment GetAppointmentById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _repository.GetAll();
        }

        public bool IsAppointmentAvailable(int doctorId, DateTime? dateTime)
        {
            return _repository.IsAvailableAppointment(doctorId, dateTime);
        }
    }
}
