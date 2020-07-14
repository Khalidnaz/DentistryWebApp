using System.ComponentModel.DataAnnotations;
using PlanetDDS.Models;

namespace PlanetDDS.Dto
{
    public class PatientCreateDto
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        public int? DentistId { get; set; }

    }
}