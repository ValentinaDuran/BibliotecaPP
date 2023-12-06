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
                .ToListAsync();
            return prestamos;


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
                // Validar que la FechaEntrega sea mayor o igual que la fecha actual
                if (prestamo.FechaEntrega < DateTime.Now)
                {
                    return BadRequest("La fecha de entrega debe ser igual o posterior a la fecha actual.");
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
            var prestamo = context.Prestamos.Where(x => x.PrestamoId == id).FirstOrDefault();

            if (prestamo == null)
            {
                return NotFound($"El Tipo Documento {id} no fue encontrado");
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


            prestamoExistente.CursoId = prestamo.CursoId;
            prestamoExistente.PrestatarioId = prestamo.PrestatarioId;
            prestamoExistente.InventarioId = prestamo.InventarioId;
            prestamoExistente.Activo = prestamo.Activo;



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
        //[HttpGet("VerificarPrestamosVencidosYConvertirEnDeudores")]
        //public async Task<ActionResult> VerificarPrestamosVencidosYConvertirEnDeudores()
        //{
        //    try
        //    {
        //        var prestamosVencidos = await context.Prestamos
        //            .Where(p => p.FechaDevolucion < DateTime.Now && p.Activo)
        //            .ToListAsync();

        //        //foreach (var prestamo in prestamosVencidos)
        //        //{
        //        //    prestamo.Activo = Deudor.DeudorId;
        //        //    context.Prestamos.Update(prestamo);
        //        //}

        //        await context.SaveChangesAsync();

        //        return Ok("Se han actualizado los préstamos vencidos a estado de deudor correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error al verificar y actualizar préstamos vencidos: {ex.Message}");
        //    }
        //}


    }
}
