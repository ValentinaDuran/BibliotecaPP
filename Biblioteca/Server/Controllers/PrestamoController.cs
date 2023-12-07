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
                //var fechaActual = DateTime.Today;

                // Validar que la FechaEntrega sea igual o posterior a la fecha actual
                if (prestamo.FechaEntrega.Date < DateTime.Today)
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

        [HttpDelete("{id:int}/{tipo}")]
        public async Task<ActionResult> Delete(int id, string tipo)
        {
            try
            {
                if (tipo.ToLower() == "prestamo")
                {
                    var prestamo = await context.Prestamos.FirstOrDefaultAsync(p => p.PrestamoId == id);

                    if (prestamo == null)
                    {
                        return NotFound($"El préstamo con ID {id} no fue encontrado.");
                    }

                    prestamo.Activo = false;
                }
                else if (tipo.ToLower() == "reserva")
                {
                    var reserva = await context.Reservas.FirstOrDefaultAsync(r => r.ReservaId == id);

                    if (reserva == null)
                    {
                        return NotFound($"La reserva con ID {id} no fue encontrada.");
                    }

                    reserva.Activo = false;
                }
                else
                {
                    return BadRequest("Tipo de entidad no válido.");
                }

                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
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
