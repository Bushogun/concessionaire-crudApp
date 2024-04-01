using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Concesionario
{
    public int ConcesionarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
