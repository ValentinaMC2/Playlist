using System.ComponentModel.DataAnnotations;

namespace Playlist.Web.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {70} caracteres")]
        [MinLength(1, ErrorMessage = "El campo {0} debe tener mínimo {1} caracter")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {30} caracteres")]
        [MinLength(1, ErrorMessage = "El campo {0} debe tener mínimo {1} caracter")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser un número entero positivo (Segundos)")]
        public int DurationInSeconds { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1900, 2024, ErrorMessage = "El año de lanzamiento debe estar entre 1900 y 2024")]
        public int ReleaseYear { get; set; }
    }
}
