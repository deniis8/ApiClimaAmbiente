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

        [Required(ErrorMessage = "O campo Data Hora é obrigatório")]
        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo Temperatura é obrigatório")]
        [Column("TEMPERATURA")]
        public int Temperatura { get; set; }

        [Required(ErrorMessage = "O campo Umidade é obrigatório")]
        [Column("UMIDADE")]
        public int Umidade { get; set; }

        [Column("D_E_L_E_T_")]
        public char Deletado { get; set; }
    }
}