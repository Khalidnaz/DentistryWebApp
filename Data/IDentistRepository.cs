using System.Collections.Generic;
using PlanetDDS.Models;

namespace PlanetDDS.Data
{
    public interface IDentistRepository
    {
        IEnumerable<Dentist> GetAllDentist();
        Dentist GetDentistById(int id);


        bool SaveChanges();

        void CreateDentist(Dentist dnt);

        void UpdateDentist(Dentist dnt);


        void DeleteDentist(Dentist dnt);

    }
}