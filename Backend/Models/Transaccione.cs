using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public partial class Transaccione
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TransaccionId { get; set; }

    public int? VehiculoId { get; set; }

    public int? ClienteId { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
