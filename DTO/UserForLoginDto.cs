using System.ComponentModel.DataAnnotations;
using PlanetDDS.Models;

namespace PlanetDDS.Dto
{
    public class UserForLoginDto
    {

        public string Username { get; set; }

        public string Password { get; set; }
    }
}