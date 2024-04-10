using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Playlist.Web.Utilities;

namespace Playlist.Web.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 106, ErrorMessage = "La edad debe estar entre {1} y {2}")]
        public int Age { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(12, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Country { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser una dirección de correo electrónico válida")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Password
        {
            get => _password;
            set => _password = PasswordUtilities.HashPassword(value); // Encrypt the password before assigning it. 
        }
        private string _password;

        //Property for password confirmation
        [NotMapped] //This property is not mapped to the database. 
        [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coinciden")]
        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ConfirmPassword { get; set; }
    }
}
