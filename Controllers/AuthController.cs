using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlanetDDS.Data;
using PlanetDDS.Dto;
using PlanetDDS.Models;

namespace PlanetDDS.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repository, IConfiguration config)
        {
            _config = config;
            _repository = repository;
        }

        //api/auth/register   "username":" ", "password": "  "
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //lowercase to have consistent data
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repository.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        //api/auth/login------"username":"   ",  "password":"   "
        //to retrieve data after login via postman: Header Tab - Key: Authorization, Value: Bearer "insert token"
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            //checking to make sure we have a user and password matches what is in db.
            var userFromRepo = await _repository.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            //created a variable for the token to store user id and username so that the db can verify user.
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };
            //key for the token. key will be stored in "AppSetting"
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            // Sign in credentials. takes the security key and a algo to hash the key.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //passing in claims and giving an expiration date/time.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            //token created based off token descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //returns token in response.
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}