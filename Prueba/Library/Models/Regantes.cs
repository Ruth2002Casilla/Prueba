using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Regantes
    {
        [Key]
        public int ReganteId { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Apellido { get; set; }

        //Este Campo es Opcional
        public string? Apodo { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Nacionalidad { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Tipo { get; set; }
    }
}
