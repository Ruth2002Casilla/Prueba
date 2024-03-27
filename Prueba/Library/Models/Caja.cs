using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Caja
    {
        [Key]
        public int CajaId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public float MontoInicial { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public float MontoFinal { get; set; }
    }
}
