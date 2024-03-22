using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public partial class Transaccione
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransaccionId { get; set; }

        public int? VehiculoId { get; set; }

        public int? ClienteId { get; set; }

        public int? ConcesionarioId { get; set; }

        public DateTime? FechaVenta { get; set; }

        public decimal? PrecioVenta { get; set; }

        public virtual Cliente? Cliente { get; set; }

        public virtual Concesionario? Concesionario { get; set; }

        public virtual Vehiculo? Vehiculo { get; set; }
    }
}
