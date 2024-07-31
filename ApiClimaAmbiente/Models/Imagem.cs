using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClimaAmbiente.Models
{
    [Table("IMAGENS")]
    public class Imagem
    {
        [Key]
        [Required]
        [Column("IDIMAGEM")]
        public int IdImagem { get; set; }

        [Column("IMAGEM")]
        public byte[] ArquivoImagem { get; set; }  // Alterado para byte[]

        /*[Column("DATAHORA")]
        public DateTime DataHora { get; set; }*/

        [Column("D_E_L_E_T_")]
        public char? Deletado { get; set; }
    }
}
