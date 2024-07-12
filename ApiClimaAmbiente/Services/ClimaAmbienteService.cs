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
                data = Convert.ToString(DateTime.Now.AddHours(-15).ToString("yyyy-MM-dd HH:mm"));

            List<ClimaAmbiente> climaAmbiente;
            climaAmbiente = _context.ClimaAmbientes.Where(c => c.Deletado != '*' && c.DataHora >= DateTime.Parse(data)).ToList();
            if (climaAmbiente.Count() > 0)
            {
                return climaAmbiente;
            }
            else
            {
                return null;
            }
        }

        public Object GetClimaAmbientePorId(int id)
        {
            //ClimaAmbiente climaAmbiente = _context.ClimaAmbientes.FirstOrDefault(climaAmbiente => climaAmbiente.IdClimaAmbiente == id);

            List<ClimaAmbiente> climaAmbiente;
            climaAmbiente = _context.ClimaAmbientes.Where(c => c.Deletado != '*' && c.IdClimaAmbiente == id).ToList();
            if (climaAmbiente.Count() > 0)
            {
                return climaAmbiente;
            }
            else
            {
                return null;
            }
        }
    }
}