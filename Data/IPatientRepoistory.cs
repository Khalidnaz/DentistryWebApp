using System.Collections.Generic;
using PlanetDDS.Models;

namespace PlanetDDS.Data
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        bool SaveChanges();
        void CreatePatient(Patient pt);
        void UpdatePatient(Patient pt);
        void DeletePatient(Patient pt);
    }
}