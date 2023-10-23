using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/PrestamoController")]
    public class PrestamoController : ControllerBase
    {
        private readonly BDContext context;

        //private readonly BDContext context;

        public PrestamoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Prestamo>>> Get()
        {
            return await context.Prestamos
                      .Include(i => i.PrestamoId)
                      .ToListAsync();


        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Prestamo>> Get(int id)
        {
            var BibliotecaVerPrestamo = await context.Prestamos.Where(o => o.PrestamoId == id).FirstOrDefaultAsync();
            if (BibliotecaVerPrestamo == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return BibliotecaVerPrestamo;
        }


        /*[HttpPost]
        public async Task<ActionResult<int>> Post(Inventario inventario)
        {
            try
            {
                context.Inventarios.Add(inventario);
                await context.SaveChangesAsync();
                return inventario.InventarioId;

            }
            catch (Exception o)
            {

                return BadRequest(o.Message);
            }
        }*/

        [HttpPost]
        public async Task<ActionResult<int>> Post(Prestamo prestamo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // Validar que la FechaEntrega sea mayor o igual que la fecha actual
                if (prestamo.FechaEntrega < DateTime.Now)
                {
                    return BadRequest("La fecha de entrega debe ser igual o posterior a la fecha actual.");
                }

                // No es necesario recuperar y establecer la propiedad Tipo. Simplemente confía en TipoId.

                var exists = await context.Prestamos.AnyAsync(t => t.PrestamoId == prestamo.PrestamoId);
                if (!exists)
                {
                    return NotFound($"El prestamo con ID {prestamo.PrestamoId} no fue encontrado.");
                }

                // Añade el objeto Inventario al contexto y guarda los cambios
                context.Prestamos.Add(prestamo);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = prestamo.PrestamoId }, prestamo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var BibliotecaBorrarPrestamo = context.Prestamos.Where(x => x.PrestamoId == id).FirstOrDefault();
            if (BibliotecaBorrarPrestamo == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Prestamos.Remove(BibliotecaBorrarPrestamo);
                context.SaveChanges();
                return Ok($"El registro de {BibliotecaBorrarPrestamo.PrestamoId} ha sido eliminado");
            }
            catch (Exception o)
            {
                return BadRequest($"No se logro eliminar por:{o.Message}");

            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Prestamo prestamo)
        {
            if (id != prestamo.PrestamoId)
            {
                return BadRequest("IDs no coinciden");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Entry(prestamo).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
