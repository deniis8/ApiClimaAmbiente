using ApiClimaAmbiente.Data;
using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Models;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ApiClimaAmbiente.Services
{
    public class ClimaAmbienteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ClimaAmbienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadClimaAmbienteDto PostClimaAmbiente(CreateClimaAmbienteDto climaAmbienteDto)
        {
            climaAmbienteDto.DataHora = DateTime.Now.AddHours(-3);

            ClimaAmbiente climaAmbiente = _mapper.Map<ClimaAmbiente>(climaAmbienteDto);
            _context.ClimaAmbientes.Add(climaAmbiente);
            _context.SaveChanges();
            return _mapper.Map<ReadClimaAmbienteDto>(climaAmbiente);
        }

        public IEnumerable RecuperaClimaAmbientePorData(string data)
        {
            if (string.IsNullOrEmpty(data))
                data = Convert.ToString(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));

            List<ClimaAmbiente> climaAmbiente;
            climaAmbiente = _context.ClimaAmbientes.ToList();

            if (climaAmbiente != null)
            {
                List<ReadClimaAmbienteDto> readClimaAmbiente = _mapper.Map<List<ReadClimaAmbienteDto>>(climaAmbiente);
                var resultado = from climaAmbi in readClimaAmbiente
                                where climaAmbi.Deletado != '*' && climaAmbi.DataHora >= DateTime.Parse(data)
                                orderby /*climaAmbi.IdClimaAmbiente descending*/ climaAmbi.DataHora /*descending*/
                                select new
                                {
                                    IdClimaAmbiente = climaAmbi.IdClimaAmbiente,
                                    DataHora = climaAmbi.DataHora,
                                    Temperatura = climaAmbi.Temperatura,
                                    Umidade = climaAmbi.Umidade
                                };
                return resultado;
            }
            return null;
        }

        public Object GetClimaAmbientePorId(int id)
        {
            ClimaAmbiente climaAmbiente = _context.ClimaAmbientes.FirstOrDefault(climaAmbiente => climaAmbiente.IdClimaAmbiente == id);

            if (climaAmbiente != null)
            {
                var resultado = (from climaAmbi in _context.ClimaAmbientes
                                 where climaAmbi.IdClimaAmbiente == id && climaAmbi.Deletado != '*'
                                 select new
                                 {
                                     IdClimaAmbiente = climaAmbi.IdClimaAmbiente,
                                     DataHora = climaAmbi.DataHora,
                                     Temperatura = climaAmbi.Temperatura,
                                     Umidade = climaAmbi.Umidade
                                 }).FirstOrDefault();

                return resultado;
            }
            return null;
        }
    }
}