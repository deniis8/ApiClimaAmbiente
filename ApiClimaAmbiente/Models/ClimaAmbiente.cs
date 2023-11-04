using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClimaAmbiente.Models
{
    [Table("CLIMAAMBIENTE")]
    public class ClimaAmbiente
    {
        [Key]
        [Required]
        [Column("ID_CLIMA_AMBIENTE")]
        public int IdClimaAmbiente { get; set; }

        //[Required(ErrorMessage = "O campo Data Hora é obrigatório")]
        [Column("DATA_HORA_CRIACAO")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo Temperatura é obrigatório")]
        [Column("TEMPERATURA")]
        public double Temperatura { get; set; }

        [Required(ErrorMessage = "O campo Umidade é obrigatório")]
        [Column("HUMIDADE")]
        public double Humidade { get; set; }

        [Column("D_E_L_E_T_")]
        public char Deletado { get; set; }
    }
}