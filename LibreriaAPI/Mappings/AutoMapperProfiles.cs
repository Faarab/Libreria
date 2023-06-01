using AutoMapper;
using LibreriaAPI.Models.Domain;
using LibreriaAPI.Models.Dto;
using LibreriaAPI.Models.Dto.Categorie;
using LibreriaAPI.Models.Dto.Marchio;
using LibreriaAPI.Models.Dto.Stato;
using LibreriaAPI.Models.Dto.Tipologia;

namespace LibreriaAPI.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Marchio, MarchioDto>().ReverseMap();
            CreateMap<Stato, StatoDto>().ReverseMap();
            CreateMap<Tipologia, TipologiaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<AddDocumento, Documento >().ReverseMap();
            CreateMap<Documento, DocumentoDto>().ReverseMap();
            CreateMap<UpdateDocumento, Documento> ().ReverseMap();
        }
    }
}
