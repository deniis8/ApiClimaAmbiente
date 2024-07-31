using ApiClimaAmbiente.Data;
using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiClimaAmbiente.Services
{
    public class ImagemService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ImagemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadImagemDto PostImagem(CreateImagemDto imagemDto)
        {
            if (string.IsNullOrEmpty(imagemDto.ArquivoImagem))
            {
                throw new ArgumentException("O campo ArquivoImagem não pode ser nulo ou vazio.");
            }

            // Converter a imagem base64 para byte[]
            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(imagemDto.ArquivoImagem);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("O formato da imagem Base64 é inválido.", ex);
            }

            // Criar a entidade Imagem
            Imagem imagem = new Imagem
            {
                ArquivoImagem = imageBytes,
                //DataHora = imagemDto.DataHora,
                Deletado = null
            };

            _context.Imagens.Add(imagem);
            _context.SaveChanges();

            return _mapper.Map<ReadImagemDto>(imagem);
        }

        public IEnumerable<Imagem> RecuperaImagemPorData()
        {
            List<Imagem> imagens;
            imagens = _context.Imagens.Where(c => c.Deletado != '*').ToList();
            if (imagens.Count() > 0)
            {
                return imagens;
            }
            else
            {
                return null;
            }
        }
    }
}
