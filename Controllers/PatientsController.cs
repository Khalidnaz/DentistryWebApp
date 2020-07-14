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
    [Route("api/Patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/patients
        [HttpGet]
        public ActionResult<IEnumerable<PatientsReadDto>> GetAllPatient()
        {
            var patientItems = _repository.GetAllPatients();

            return Ok(_mapper.Map<IEnumerable<PatientsReadDto>>(patientItems));
        }

        //Get api/patients/{id}
        [HttpGet("{id}")]
        public ActionResult<PatientsReadDto> GetPatientById(int id)
        {
            var patientItem = _repository.GetPatientById(id);
            if (patientItem != null)
            {
                return Ok(_mapper.Map<PatientsReadDto>(patientItem));
            }
            return NotFound();
        }

        //Post api/patients
        [HttpPost]
        public ActionResult<PatientsReadDto> Createpatient(PatientCreateDto patientCreateDto)
        {
            var patientModel = _mapper.Map<Patient>(patientCreateDto);
            _repository.CreatePatient(patientModel);
            _repository.SaveChanges();

            return Ok(patientModel);
        }

        //Put api/patients/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePatient(int id, PatientCreateDto patientCreateDto)
        {
            var patientModelFromRepo = _repository.GetPatientById(id);
            if (patientModelFromRepo == null)
            {
                return NotFound();
            }
            //maping data from patientCreateDto to patientModelFromRepo
            _mapper.Map(patientCreateDto, patientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/patients/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePatients(int id)
        {
            var patientModelFromRepo = _repository.GetPatientById(id);
            if (patientModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePatient(patientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}