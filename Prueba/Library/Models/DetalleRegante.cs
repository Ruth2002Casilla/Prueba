using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class DetalleRegante
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Regantes")]
        public int ReganteId { get; set; }

        [ForeignKey("Parcela")]
        public int ParcelaId { get; set; }

        [ForeignKey("Bloque")]
        public int BloqueId { get; set; }

        [ForeignKey("Asociacion")]
        public int AsociacionId { get; set; }

        [Required(ErrorMessage = "Este campor es Obligatorio")]
        public string? Estado { get; set; }
    }
}
