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
            var prestamos = await context.Prestamos
                .Include(i => i.Inventario)
                .ThenInclude(t =>t.Tipo)
                .Include(i => i.Prestatario)
                .Include(i => i.Curso)
                .Where(a => a.Activo == true)
                .Where (d => d.EsDeudor == false)
                .ToListAsync();
            return prestamos;


        }
        //trae los datos a la tabla deudor
        [HttpGet("deudor-true")]
        public async Task<ActionResult<List<Prestamo>>> GetPasarTrue()
        {
            return await context.Prestamos
                .Include(i => i.Inventario)
                .ThenInclude(t => t.Tipo)
                .Include(i => i.Prestatario)
                .Include(i => i.Curso)
                .Where(d => d.EsDeudor == true)
                .Where(a => a.Activo == true)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Prestamo>> Get(int id)
        {
            var BibliotecaVerPrestamo = await context.Prestamos
               
                .Include(i => i.Inventario)
                .ThenInclude(t => t.Tipo)
                .Include(i => i.Prestatario)
                .Include(i => i.Curso)
                .Where(o => o.PrestamoId == id)
                .FirstOrDefaultAsync();

            //var BibliotecaVerPrestamo = await context.Prestamos.Where(o => o.PrestamoId == id).FirstOrDefaultAsync();
            if (BibliotecaVerPrestamo == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return BibliotecaVerPrestamo;
            

        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Prestamo prestamo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //var fechaActual = DateTime.Today;

                // Validar que la FechaEntrega sea igual o posterior a la fecha actual
                if (prestamo.FechaEntrega.Date < DateTime.Today)
                {
                    return BadRequest("La fecha de entrega debe ser igual o posterior a la fecha actual.");
                }
                if (prestamo.FechaDevolucion.Date < prestamo.FechaEntrega.Date)
                {
                    return BadRequest("La fecha de devolución debe ser igual o posterior a la fecha actual.");
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
        public async Task<ActionResult> Delete(int id)
        {
            var prestamo = context.Prestamos.Where(x => x.PrestamoId == id).FirstOrDefault();

            if (prestamo == null)
            {
                return NotFound($"El prestamo {id} no fue encontrado");
            }
            if (prestamo != null)
            {
                prestamo.Activo = false;
                context.SaveChanges();

            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.PrestamoId)
            {
                return BadRequest("IDs no coinciden");
            }
            var prestamoExistente = context.Prestamos.SingleOrDefault(o => o.PrestamoId == id);
            //var prestamoExistente = context.Prestamos.Where(o => o.PrestamoId == id).FirstOrDefault();

            if (prestamoExistente == null)
            {
                return NotFound("No existe el inventario");
            }


            //prestamoExistente.CursoId = prestamo.CursoId;
            //prestamoExistente.PrestatarioId = prestamo.PrestatarioId;
            //prestamoExistente.InventarioId = prestamo.InventarioId;
            prestamoExistente.Activo = prestamo.Activo;
            prestamoExistente.FechaDevolucion = prestamo.FechaDevolucion;



            // Actualiza otras propiedades según sea necesario

            try
            {
                context.Prestamos.Update(prestamoExistente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

        [HttpPut("deudor/{id:int}")]
        public ActionResult Activar(int id)
        {
            var prestamo = context.Prestamos.SingleOrDefault(e => e.PrestamoId == id);

            if (prestamo == null)
            {
                return NotFound("No existe el prestamo");
            }

            prestamo.EsDeudor = true;

            try
            {
                context.Prestamos.Update(prestamo);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }


    }
}
