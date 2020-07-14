using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetDDS.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        public int? DentistId { get; set; }
        public Dentist Dentist { get; set; }


    }
}