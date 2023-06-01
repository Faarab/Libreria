using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibreriaAPI.Models.Dto.Categorie
{
    public class AddCategoria
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength (3, ErrorMessage = "Il cmapo deve contenere almeno 3 caratteri")]
        [MaxLength(5, ErrorMessage = "Il campo deve contenere massimo 5 caratteri")]
        public string Code { get; set; }
    }
}
