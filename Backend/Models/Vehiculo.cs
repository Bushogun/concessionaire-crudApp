﻿using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public decimal? Precio { get; set; }

    public int? ConcesionarioId { get; set; }

    public virtual Concesionario? Concesionario { get; set; }

    public virtual Transaccione? Transaccione { get; set; }
}
