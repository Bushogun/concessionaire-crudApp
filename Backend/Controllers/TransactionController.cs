using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        public VentasController(VentasVehiculosContext context)
        {
            _context = context;
        }

        private readonly VentasVehiculosContext _context;

        //GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccione>>> GetTransacciones()
        {
            try
            {
                var transacciones = await _context.Transacciones
                    .Include(t => t.Cliente)
                    .Include(t => t.Concesionario)
                    .Include(t => t.Vehiculo)
                    .ToListAsync();
                return transacciones;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccione>> GetTransactionItem(int id)
        {
            try
            {
                var transaction = await _context.Transacciones
                    .Include(t => t.Cliente)
                    .Include(t => t.Concesionario)
                    .Include(t => t.Vehiculo)
                    .FirstOrDefaultAsync(t => t.TransaccionId == id);

                if (transaction == null)
                {
                    return NotFound();
                }

                return transaction;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult<Transaccione>> PostTransaction(int vehiculoId, int clienteId, int concesionarioId, decimal precioVenta )
        {
            var transaccion = new Transaccione
            {
                VehiculoId = vehiculoId,
                ClienteId = clienteId,
                ConcesionarioId = concesionarioId,
                FechaVenta = DateTime.Now,
                PrecioVenta = precioVenta,
            };
            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaccion.TransaccionId }, transaccion) ;
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Transaccione>> PutTransaction(int id, Transaccione transaccion)
        {
            if (id != transaccion.TransaccionId)
            {
                return BadRequest(); 
            }

            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if(!TransaccionExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TransaccionExist(int id)
        {
            return _context.Transacciones.Any(e => e.TransaccionId == id);
        }

    }

}
