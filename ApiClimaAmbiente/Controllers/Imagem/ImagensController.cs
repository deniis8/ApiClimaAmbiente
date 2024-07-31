using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiClimaAmbiente.Controllers
{
    [Route("api/[controller]")]
    public class ImagensController : ControllerBase
    {
        private readonly ImagemService _imagemService;

        public ImagensController(ImagemService imagemService)
        {
            _imagemService = imagemService;
        }

        [HttpPost]
        public IActionResult PostImagem([FromBody] CreateImagemDto imagemDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var readDto = _imagemService.PostImagem(imagemDto);
                return CreatedAtAction(nameof(PostImagem), new { IdImagem = readDto.IdImagem }, readDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Erro de validação: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet()]
        public IActionResult GetImagem()
        {
            try
            {
                var readDto = _imagemService.RecuperaImagemPorData();
                if (readDto == null) return NotFound();
                return Ok(readDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        /*
        [HttpGet("data/{data}")]
        public IActionResult GetImagemPorData(string data)
        {
            try
            {
                var readDto = _imagemService.RecuperaImagemPorData(data);
                if (readDto == null) return NotFound();
                return Ok(readDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }*/
    }
}
