using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/ReservaController")]
    public class ReservaController: ControllerBase
    {
        private readonly BDContext context;
        public ReservaController(BDContext context)
        {
            this.context = context;
     
        }

        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> Get()
        {
            var reservas = await context.Reservas
                .Include(i => i.Inventario)
                .ThenInclude(t => t.Tipo)
                .Include(i => i.Prestatario)
                .Include(i => i.Curso)
                .Where(a => a.Activo == true)
                .ToListAsync();
            return reservas;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reserva>> Get(int id)
        {
            var BibliotecaVerReserva = await context.Reservas

                .Include(i => i.Inventario)
                .ThenInclude(i => i.Tipo)
                .Include(i => i.Prestatario)
                .Include(i => i.Curso)
                .Where(o => o.ReservaId == id)
                .FirstOrDefaultAsync();

            if (BibliotecaVerReserva == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return BibliotecaVerReserva;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Reserva reserva)
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


                // Añade el objeto al contexto y guarda los cambios
                context.Reservas.Add(reserva);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = reserva.ReservaId }, reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Reserva reserva)
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


            ReservaExistente.CursoId = reserva.CursoId;
            ReservaExistente.PrestatarioId = reserva.PrestatarioId;
            ReservaExistente.InventarioId = reserva.InventarioId;

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

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
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
