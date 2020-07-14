using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanetDDS.Models;

namespace PlanetDDS.Data
{
    public class DentistRepository : IDentistRepository
    {
        private readonly DataContext _context;
        public DentistRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Dentist> GetAllDentist()
        {
            return _context.Dentists.ToList();
        }

        public Dentist GetDentistById(int id)
        {
            return _context.Dentists.FirstOrDefault(p => p.DentistId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateDentist(Dentist dnt)
        {
            _context.Dentists.Add(dnt);
        }

        public void UpdateDentist(Dentist dnt)
        {

        }

        public void DeleteDentist(Dentist dnt)
        {
            _context.Dentists.Remove(dnt);
        }

    }
}