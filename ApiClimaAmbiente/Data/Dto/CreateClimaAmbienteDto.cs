﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClimaAmbiente.Data.Dto
{
    public class CreateClimaAmbienteDto
    {
        [Required(ErrorMessage = "O campo Data Hora é obrigatório")]
        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo Temperatura é obrigatório")]
        [Column("TEMPERATURA")]
        public double Temperatura { get; set; }

        [Required(ErrorMessage = "O campo Umidade é obrigatório")]
        [Column("UMIDADE")]
        public double Umidade { get; set; }
    }
}