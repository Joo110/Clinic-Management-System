using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic
{
    public class clsAppointmentData
    {
        private readonly AppDbContext _context;

        public clsAppointmentData(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment.Id;
        }

        public bool Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            return _context.SaveChanges() > 0;
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public List<Appointment> GetAll()
        {
            try
            {
                var appointments = _context.Appointments
                    .Where(a => a.Date.HasValue)
                    .ToList();

                return appointments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Appointment>();
            }
        }


        public bool Exists(int id)
        {
            return _context.Appointments.Any(a => a.Id == id);
        }

        public bool IsAvailableAppointment(int doctorId, DateTime? dateTime)
        {
            try
            {
                return !_context.Appointments.Any(a =>
                    a.DoctorId == doctorId &&
                    a.Date.HasValue && a.Date.Value == dateTime &&
                    a.AppointmentStatusId == 4);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
