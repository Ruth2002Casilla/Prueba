using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Asociacion
    {
        [Key]
        public int AsociacionId { get; set; }

        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string? Nombre { get; set; }
    }
}
