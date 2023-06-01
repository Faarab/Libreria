using LibreriaAPI.Models.Dto.Categorie;
using LibreriaAPI.Models.Dto.Marchio;
using LibreriaAPI.Models.Dto.Stato;
using LibreriaAPI.Models.Dto.Tipologia;
using System.ComponentModel.DataAnnotations;

namespace LibreriaAPI.Models.Dto
{
    public class DocumentoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Il cmapo deve contenere almeno 4 caratteri")]
        [MaxLength(4, ErrorMessage = "Il campo deve contenere massimo 4 caratteri")]
        public int AnnoDiRilascio { get; set; }
        public string Icona { get; set; }

        public CategoriaDto Categoria { get; set; }
        public StatoDto Stato { get; set; } 
        public TipologiaDto Tipologia { get; set; }
        public MarchioDto Marchio { get; set; }
    }
}
