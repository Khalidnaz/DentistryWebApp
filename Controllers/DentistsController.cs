using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanetDDS.Data;
using PlanetDDS.Dto;
using PlanetDDS.Models;

namespace PlanetDDS.Controllers
{
    [Authorize]
    [Route("api/Dentists")]
    [ApiController]
    public class DentistsController : ControllerBase
    {
        private readonly IDentistRepository _repository;
        private readonly IMapper _mapper;

        public DentistsController(IDentistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        ///Get api/Dentists
        [HttpGet]
        public ActionResult<IEnumerable<DentistsReadDto>> GetAllDentist()
        {
            var dentistItems = _repository.GetAllDentist();

            return Ok(_mapper.Map<IEnumerable<DentistsReadDto>>(dentistItems));
        }

        //Get api/dentists/{id}
        [HttpGet("{id}")]
        public ActionResult<DentistsReadDto> GetDentistById(int id)
        {
            var dentistItem = _repository.GetDentistById(id);
            if (dentistItem != null)
            {
                return Ok(_mapper.Map<DentistsReadDto>(dentistItem));
            }
            return NotFound();
        }

        //Post api/dentists
        [HttpPost]
        public ActionResult<DentistsReadDto> CreateDentist(DentistCreateDto dentistCreateDto)
        {
            var dentistModel = _mapper.Map<Dentist>(dentistCreateDto);
            _repository.CreateDentist(dentistModel);
            _repository.SaveChanges();

            return Ok(dentistModel);
        }

        //Put api/dentists/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDentist(int id, DentistCreateDto dentistCreateDto)
        {
            var dentistModelFromRepo = _repository.GetDentistById(id);
            if (dentistModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(dentistCreateDto, dentistModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/dentists/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDentist(int id)
        {
            var dentistModelFromRepo = _repository.GetDentistById(id);
            if (dentistModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteDentist(dentistModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}