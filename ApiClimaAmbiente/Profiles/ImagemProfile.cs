using ApiClimaAmbiente.Data.Dto;
using ApiClimaAmbiente.Models;
using AutoMapper;

namespace ApiClimaAmbiente.Profiles
{
    public class ImagemProfile : Profile
    {
        public ImagemProfile()
        {
            CreateMap<CreateImagemDto, Imagem>();
            CreateMap<Imagem, ReadImagemDto>();
        }
    }
}