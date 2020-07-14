using AutoMapper;
using PlanetDDS.Dto;
using PlanetDDS.Models;

namespace PlanetDDS.Profiles
{
    public class PlanetDDSProfile : Profile
    {
        public PlanetDDSProfile()
        {
            //Source -> Target
            CreateMap<Dentist, DentistsReadDto>();
            CreateMap<DentistCreateDto, Dentist>();

            CreateMap<Patient, PatientsReadDto>();
            CreateMap<PatientCreateDto, Patient>();
        }
    }
}