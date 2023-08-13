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
            ClimaAmbiente climaAmbiente = _mapper.Map<ClimaAmbiente>(climaAmbienteDto);
            _context.ClimaAmbientes.Add(climaAmbiente);
            _context.SaveChanges();
            return _mapper.Map<ReadClimaAmbienteDto>(climaAmbiente);
        }

        public IEnumerable RecuperaLancamentosPorData(string data)
        {
            if (string.IsNullOrEmpty(data))
                data = Convert.ToString(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));

            List<ClimaAmbiente> climaAmbiente;
            climaAmbiente = _context.ClimaAmbientes.ToList();

            if (climaAmbiente != null)
            {
                List<ReadClimaAmbienteDto> readClimaAmbiente = _mapper.Map<List<ReadClimaAmbienteDto>>(climaAmbiente);
                var resultado = from climaAmbi in readClimaAmbiente
                                where climaAmbi.Deletado != '*' && climaAmbi.DataHora >= DateTime.Parse(data)
                                orderby climaAmbi.DataHora descending
                                select new
                                {
                                    IdClimaTempo = climaAmbi.IdClimaTempo,
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
            ClimaAmbiente climaAmbiente = _context.ClimaAmbientes.FirstOrDefault(climaAmbiente => climaAmbiente.IdClimaTempo == id);

            if (climaAmbiente != null)
            {
                var resultado = (from climaAmbi in _context.ClimaAmbientes
                                 where climaAmbi.IdClimaTempo == id && climaAmbi.Deletado != '*'
                                 select new
                                 {
                                     IdClimaTempo = climaAmbi.IdClimaTempo,
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