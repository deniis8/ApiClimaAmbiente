using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
