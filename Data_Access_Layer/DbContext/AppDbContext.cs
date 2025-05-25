using Data_Access_Layer_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_Clinic.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalSpecialties> MedicalSpecialties { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<CareerSpecialization> CareerSpecializations { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }

    }
}
