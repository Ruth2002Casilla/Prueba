using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Contrasena { get; set; }
    }
}
