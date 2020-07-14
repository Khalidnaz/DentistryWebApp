using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanetDDS.Models;

namespace PlanetDDS.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            //including Dentist details
            return _context.Patients.Include(p => p.Dentist).ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.Include(p => p.Dentist).FirstOrDefault(p => p.PatientId == id);
        }

        //save changes to the DB
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreatePatient(Patient pt)
        {
            _context.Patients.Add(pt);
        }

        public void UpdatePatient(Patient pt)
        {

        }

        public void DeletePatient(Patient pt)
        {
            _context.Patients.Remove(pt);
        }
    }
}