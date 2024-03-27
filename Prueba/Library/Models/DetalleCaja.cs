using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class DetalleCaja
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Caja")]
        public int CajaId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? NombreUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public float Monto { get; set; }


    }
}
