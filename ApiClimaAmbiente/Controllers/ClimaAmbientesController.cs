using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;

namespace ApiClimaAmbiente.Controllers
{
    [Route("api/[controller]")]
    public class ClimaAmbientesController : ControllerBase
    {
        private ClimaAmbienteService _climaAmbienteService;

        public ClimaAmbientesController(ClimaAmbienteService climaAmbienteService)
        {
            _climaAmbienteService = climaAmbienteService;
        }

        [HttpPost]
        public IActionResult PostClimaAmbiete([FromBody] CreateClimaAmbienteDto climaAmbienteDto)
        {
            ReadClimaAmbienteDto readDto = _climaAmbienteService.PostClimaAmbiente(climaAmbienteDto);
            return CreatedAtAction(nameof(PostClimaAmbiete), new { IdClimaTempo = readDto.IdClimaTempo }, readDto);
        }

        [HttpGet("data/{data}")]
        public IActionResult GetClimaAmbientePorData(string data)
        {
            IEnumerable readDto = _climaAmbienteService.RecuperaLancamentosPorData(data);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("data")]
        public IActionResult GetClimaAmbiente()
        {
            IEnumerable readDto = _climaAmbienteService.RecuperaLancamentosPorData(null);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetClimaAmbientePorId(int id)
        {
            Object readDto = _climaAmbienteService.GetClimaAmbientePorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }
    }
}