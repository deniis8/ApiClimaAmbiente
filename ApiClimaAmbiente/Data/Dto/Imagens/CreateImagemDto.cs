using System;
using System.ComponentModel.DataAnnotations;

namespace ApiClimaAmbiente.Data.Dto
{
    public class CreateImagemDto
    {
        [Required(ErrorMessage = "O campo Imagem é obrigatório")]
        public string ArquivoImagem { get; set; } 
    }
}
