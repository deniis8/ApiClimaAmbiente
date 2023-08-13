using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Models;
using AutoMapper;

namespace ApiClimaAmbiente.Profiles
{
    public class ClimaAmbienteProfile : Profile
    {
        public ClimaAmbienteProfile()
        {
            CreateMap<CreateClimaAmbienteDto, ClimaAmbiente>();
            CreateMap<ClimaAmbiente, ReadClimaAmbienteDto>();
        }
    }
}