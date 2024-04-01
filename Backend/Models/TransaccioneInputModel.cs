using System;

namespace Backend.Models
{
    public class TransaccioneInputModel
    {
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
