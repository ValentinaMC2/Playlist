using System.ComponentModel.DataAnnotations;

namespace Playlist.Web.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }

        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "El campo {0} debe tener mínimo {1} caracter")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Title { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "El campo {0} debe tener mínimo {1} caracter")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Genre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser un número entero positivo (Segundos)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int DurationInSeconds { get; set; }

        [Range(1900, 2024, ErrorMessage = "El año de lanzamiento debe estar entre {1} y {2}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ReleaseYear { get; set; }

        public int UserId { get; set; } //User ID associated with the song.
    }
}
