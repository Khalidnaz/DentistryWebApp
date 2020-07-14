using Microsoft.EntityFrameworkCore;
using PlanetDDS.Models;

namespace PlanetDDS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}