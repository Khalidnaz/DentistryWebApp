using System.ComponentModel.DataAnnotations;
using PlanetDDS.Models;

namespace PlanetDDS.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}