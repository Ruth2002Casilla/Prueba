using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ParametroOperacionales
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public float MontoGravedad { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public float MontoBomba { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public float Impuestos { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public float Recargos { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TiempoRecargos { get; set; }
    }
}
