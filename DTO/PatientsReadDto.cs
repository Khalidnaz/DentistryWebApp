using PlanetDDS.Models;

namespace PlanetDDS.Dto
{
    public class PatientsReadDto
    {
        public int PatientId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? DentistId { get; set; }
        public Dentist Dentist { get; set; }

    }
}