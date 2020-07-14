using System.ComponentModel.DataAnnotations;

namespace PlanetDDS.Dto
{
    public class DentistCreateDto
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
    }
}