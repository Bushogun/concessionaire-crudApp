using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentasVehiculosContext _context;

        public VentasController(VentasVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetTransacciones()
        {
            try
            {
                var transacciones = await _context.Transacciones
                    .Select(t => new
                    {
                        t.TransaccionId,
                        t.VehiculoId,
                        t.ClienteId,
                        t.FechaVenta,
                        t.PrecioVenta,
                        Cliente = new
                        {
                            t.Cliente!.ClienteId,
                            t.Cliente.Nombre,
                            t.Cliente.Email,
                            t.Cliente.Telefono
                        },
                        Vehiculo = new
                        {
                            t.Vehiculo!.VehiculoId,
                            t.Vehiculo.Marca,
                            t.Vehiculo.Modelo,
                            t.Vehiculo.Anio,
                            t.Vehiculo.Precio
                        }
                    })
                    .ToListAsync();

                return transacciones;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccione>> GetTransaccion(int id)
        {
            try
            {
                var transaccion = await _context.Transacciones
                    .Where(t => t.TransaccionId == id)
                    .Include(t => t.Cliente)
                    .Include(t => t.Vehiculo)
                    .FirstOrDefaultAsync();

                if (transaccion == null)
                {
                    return NotFound();
                }

                var transaccionViewModel = new Transaccione
                {
                    TransaccionId = transaccion.TransaccionId,
                    VehiculoId = transaccion.VehiculoId,
                    ClienteId = transaccion.ClienteId,
                    FechaVenta = transaccion.FechaVenta,
                    PrecioVenta = transaccion.PrecioVenta,
                    Cliente = new Cliente
                    {
                        ClienteId = transaccion.Cliente!.ClienteId,
                        Nombre = transaccion.Cliente.Nombre,
                        Email = transaccion.Cliente.Email,
                        Telefono = transaccion.Cliente.Telefono
                    },
                    Vehiculo = new Vehiculo
                    {
                        VehiculoId = transaccion.Vehiculo!.VehiculoId,
                        Marca = transaccion.Vehiculo.Marca,
                        Modelo = transaccion.Vehiculo.Modelo,
                        Anio = transaccion.Vehiculo.Anio,
                        Precio = transaccion.Vehiculo.Precio
                    }
                };

                return transaccionViewModel;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult<Transaccione>> PostTransaccion(TransaccioneInputModel model)
        {
            try
            {
                var transaccion = new Transaccione
                {
                    VehiculoId = model.VehiculoId,
                    ClienteId = model.ClienteId,
                    PrecioVenta = model.PrecioVenta,
                    FechaVenta = DateTime.Now
                };

                _context.Transacciones.Add(transaccion);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTransaccion", new { id = transaccion.TransaccionId }, transaccion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la transacción: {ex}");
                return StatusCode(500, "Error al guardar la transacción. Consulta los registros del servidor para obtener más detalles.");
            }
        }



        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccion(int id, TransaccioneInputModel model)
        {
            try
            {
                var existingTransaccion = await _context.Transacciones.FindAsync(id);

                if (existingTransaccion == null)
                {
                    return NotFound();
                }

                existingTransaccion.VehiculoId = model.VehiculoId;
                existingTransaccion.ClienteId = model.ClienteId;
                existingTransaccion.PrecioVenta = model.PrecioVenta;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la transacción: {ex}");
                return StatusCode(500, "Error al actualizar la transacción. Consulta los registros del servidor para obtener más detalles.");
            }
        }

    }
}
