using Playlist.Web.Utilities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Playlist.Web.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {50} caracteres")] 
        [MinLength(1, ErrorMessage = "El campo {0} debe tener mínimo {1} caracter")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 106, ErrorMessage = "La edad debe estar entre {1} y {106}")]
        public int Age { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Country { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime RegistrationDate { get; set; }

        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {70} caracteres")]
        [MinLength(1, ErrorMessage = "El campo {0} debe tener mínimo {1} caracter")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser una dirección de correo electrónico válida")]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password
        {
            get => _password;
            set => _password = PasswordUtilities.HashPassword(value); // Encrypt the password before assigning it. 
        }
        private string _password;


    }
}
