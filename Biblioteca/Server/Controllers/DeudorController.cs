using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/DeudorControLler")]
    public class DeudorController : ControllerBase
    {
        private readonly BDContext context;

        //private readonly BDContext context;

        public DeudorController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet("Deudores")]
        public async Task<ActionResult<List<Deudor>>> GetDeudores()
        {
            var deudores = await context.Deudores
                .Include(d => d.Prestamo)
                .Include(d => d.Reserva)
                .Where(a => a.EsDeudor == false)
                .ToListAsync();

            return deudores;
        }


        // Endpoints para operaciones relacionadas con préstamos
        [HttpGet("Prestamos")]
        public async Task<ActionResult<List<Prestamo>>> GetPrestamos()
        {
            var prestamos = await context.Prestamos
                .Include(p => p.Inventario)
                .Include(p => p.Prestatario)
                .Include(p => p.Curso)
                .Where(p => p.Activo)
                .ToListAsync();
            return prestamos;
        }

        [HttpGet("Prestamos/{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
            var prestamo = await context.Prestamos
                .Include(p => p.Inventario)
                .Include(p => p.Prestatario)
                .Include(p => p.Curso)
                .FirstOrDefaultAsync(p => p.PrestamoId == id);

            if (prestamo == null)
            {
                return NotFound($"No se encontró un préstamo con ID {id}");
            }

            return prestamo;
        }

        [HttpPut("Prestamos/{id}")]
        public ActionResult PutPrestamo(int id, [FromBody] Prestamo prestamo)
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

        [HttpDelete("Prestamos/{id}")]
        public ActionResult DeletePrestamo(int id)
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

        // Endpoints para operaciones relacionadas con reservas
        [HttpGet("Reservas")]
        public async Task<ActionResult<List<Reserva>>> GetReservas()
        {
            var reservas = await context.Reservas
                .Include(r => r.Inventario)
                .Include(r => r.Prestatario)
                .Include(r => r.Curso)
                .Where(r => r.Activo)
                .ToListAsync();
            return reservas;
        }

        [HttpGet("Reservas/{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await context.Reservas
                .Include(r => r.Inventario)
                .Include(r => r.Prestatario)
                .Include(r => r.Curso)
                .FirstOrDefaultAsync(r => r.ReservaId == id);

            if (reserva == null)
            {
                return NotFound($"No se encontró una reserva con ID {id}");
            }

            return reserva;
        }

        [HttpPut("Reservas/{id}")]
        public ActionResult PutReserva(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return BadRequest("IDs no coinciden");
            }
            var ReservaExistente = context.Reservas.SingleOrDefault(o => o.ReservaId == id);

            if (ReservaExistente == null)
            {
                return NotFound("No existe el inventario");
            }


            ReservaExistente.Activo = reserva.Activo;

            // Actualiza otras propiedades según sea necesario
            try
            {
                context.Reservas.Update(ReservaExistente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
            
        }

        [HttpDelete("Reservas/{id}")]
        public ActionResult DeleteReserva(int id)
        {
            var reserva = context.Reservas.Where(x => x.ReservaId == id).FirstOrDefault();

            if (reserva == null)
            {
                return NotFound($"El Tipo Documento {id} no fue encontrado");
            }
            if (reserva != null)
            {
                reserva.Activo = false;
                context.SaveChanges();

            }
           

            return Ok();
        }
    }
}
    //
    //[HttpGet]
    //    public async Task<ActionResult<List<Prestamo>>> Get()
    //    {
    //        var prestamos = await context.Prestamos
    //            .Include(i => i.Inventario)
    //            .ThenInclude(t => t.Tipo)
    //            .Include(i => i.Prestatario)
    //            .Include(i => i.Curso)
    //            .Where(a => a.Activo == true)
    //            .ToListAsync();
    //        return prestamos;


    //    }
    //    [HttpGet("{id:int}")]
    //    public async Task<ActionResult<Prestamo>> Get(int id)
    //    {
    //        var BibliotecaVerPrestamo = await context.Prestamos

    //            .Include(i => i.Inventario)
    //            .ThenInclude(t => t.Tipo)
    //            .Include(i => i.Prestatario)
    //            .Include(i => i.Curso)
    //            .Where(o => o.PrestamoId == id)
    //            .FirstOrDefaultAsync();

    //        //var BibliotecaVerPrestamo = await context.Prestamos.Where(o => o.PrestamoId == id).FirstOrDefaultAsync();
    //        if (BibliotecaVerPrestamo == null)
    //        {
    //            return NotFound($"No existe ese material en el inventario de Id={id}");
    //        }
    //        return BibliotecaVerPrestamo;


    //    }
    //    [HttpGet]
    //    public async Task<ActionResult<List<Reserva>>> Get()
    //    {
    //        var reservas = await context.Reservas
    //            .Include(i => i.Inventario)
    //            .ThenInclude(t => t.Tipo)
    //            .Include(i => i.Prestatario)
    //            .Include(i => i.Curso)
    //            .Where(a => a.Activo == true)
    //            .ToListAsync();
    //        return reservas;
    //    }

    //    [HttpGet("{id:int}")]
    //    public async Task<ActionResult<Reserva>> Get(int id)
    //    {
    //        var BibliotecaVerReserva = await context.Reservas

    //            .Include(i => i.Inventario)
    //            .ThenInclude(i => i.Tipo)
    //            .Include(i => i.Prestatario)
    //            .Include(i => i.Curso)
    //            .Where(o => o.ReservaId == id)
    //            .FirstOrDefaultAsync();

    //        if (BibliotecaVerReserva == null)
    //        {
    //            return NotFound($"No existe ese material en el inventario de Id={id}");
    //        }
    //        return BibliotecaVerReserva;
    //    }
    //    [HttpPut("{id:int}")]
    //    public ActionResult Put(int id, [FromBody] Prestamo prestamo)
    //    {
    //        if (id != prestamo.PrestamoId)
    //        {
    //            return BadRequest("IDs no coinciden");
    //        }
    //        var prestamoExistente = context.Prestamos.SingleOrDefault(o => o.PrestamoId == id);
    //        //var prestamoExistente = context.Prestamos.Where(o => o.PrestamoId == id).FirstOrDefault();

    //        if (prestamoExistente == null)
    //        {
    //            return NotFound("No existe el inventario");
    //        }


    //        prestamoExistente.Activo = prestamo.Activo;
    //        // Actualiza otras propiedades según sea necesario

    //        try
    //        {
    //            context.Prestamos.Update(prestamoExistente);
    //            context.SaveChanges();
    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
    //        }
    //    }
    //    [HttpDelete("{id:int}/{tipo}")]
    //    public async Task<ActionResult> Delete(int id, string tipo)
    //    {
    //        try
    //        {
    //            if (tipo.ToLower() == "prestamo")
    //            {
    //                var prestamo = await context.Prestamos.FirstOrDefaultAsync(p => p.PrestamoId == id);

    //                if (prestamo == null)
    //                {
    //                    return NotFound($"El préstamo con ID {id} no fue encontrado.");
    //                }

    //                prestamo.Activo = false;
    //            }
    //            else if (tipo.ToLower() == "reserva")
    //            {
    //                var reserva = await context.Reservas.FirstOrDefaultAsync(r => r.ReservaId == id);

    //                if (reserva == null)
    //                {
    //                    return NotFound($"La reserva con ID {id} no fue encontrada.");
    //                }

    //                reserva.Activo = false;
    //            }
    //            else
    //            {
    //                return BadRequest("Tipo de entidad no válido.");
    //            }

    //            await context.SaveChangesAsync();

    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest($"Error al procesar la solicitud: {ex.Message}");
    //        }
    //    }
    //    [HttpPut("{id:int}")]
    //    public ActionResult Put(int id, [FromBody] Reserva reserva)
    //    {
    //        if (id != reserva.ReservaId)
    //        {
    //            return BadRequest("IDs no coinciden");
    //        }
    //        var ReservaExistente = context.Reservas.SingleOrDefault(o => o.ReservaId == id);

    //        if (ReservaExistente == null)
    //        {
    //            return NotFound("No existe el inventario");
    //        }


    //        ReservaExistente.CursoId = reserva.CursoId;
    //        ReservaExistente.PrestatarioId = reserva.PrestatarioId;
    //        ReservaExistente.InventarioId = reserva.InventarioId;
    //        ReservaExistente.Pasar = reserva.Pasar;
    //        ReservaExistente.Activo = reserva.Activo;

    //        // Actualiza otras propiedades según sea necesario
    //        try
    //        {
    //            context.Reservas.Update(ReservaExistente);
    //            context.SaveChanges();
    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
    //        }
    //    }

    //    [HttpDelete("{id:int}")]
    //    public ActionResult Delete(int id)
    //    {
    //        var reserva = context.Reservas.Where(x => x.ReservaId == id).FirstOrDefault();

    //        if (reserva == null)
    //        {
    //            return NotFound($"El Tipo Documento {id} no fue encontrado");
    //        }
    //        if (reserva != null)
    //        {
    //            reserva.Activo = false;
    //            context.SaveChanges();

    //        }
    //        return Ok();
    //    }



