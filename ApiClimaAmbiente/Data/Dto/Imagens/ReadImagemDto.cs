using System;
using System.ComponentModel.DataAnnotations;

namespace ApiClimaAmbiente.Data.Dto
{
    public class ReadImagemDto
    {
        [Key]
        [Required]
        public int IdImagem { get; set; }

        [Required(ErrorMessage = "O campo Imagem é obrigatório")]
        public string ArquivoImagem { get; set; }  // Base64 encoded image string

        [Required(ErrorMessage = "O campo Data Hora é obrigatório")]
        public DateTime DataHora { get; set; }

        public char? Deletado { get; set; }
    }
}
