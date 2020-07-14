using System.ComponentModel.DataAnnotations;

namespace PlanetDDS.Models
{
    public class Dentist
    {
        [Key]
        public int DentistId { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
    }
}