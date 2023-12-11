using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/PrestatariosController")]
    public class PrestatariosController : ControllerBase
    {
        private readonly BDContext context;

        public PrestatariosController(BDContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Prestatario>>> Get()
        {
            return await context.Prestatarios.ToListAsync();


        }
        //AGREGA UN NUEVO PRESTATARIO
        [HttpPost]
        public async Task<ActionResult<int>> Post(Prestatario prestatario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (string.IsNullOrWhiteSpace(prestatario.NombreApellido))
                {
                    ModelState.AddModelError(nameof(Prestatario.NombreApellido), "El campo NombreApellido es obligatorio.");
                    return BadRequest(ModelState);
                }


                // Añade el objeto al contexto y guarda los cambios
                context.Prestatarios.Add(prestatario);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = prestatario.PrestatarioId }, prestatario);
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepciones de la base de datos
                return BadRequest("Error al guardar en la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                return BadRequest("Error: " + ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Prestatario prestatario)
        {
            if (id != prestatario.PrestatarioId)
            {
                return BadRequest("IDs no coinciden");
            }

            var prestatarioExistente = context.Prestatarios.SingleOrDefault(e => e.PrestatarioId == id);

            if (prestatarioExistente == null)
            {
                return NotFound("No existe el inventario");
            }


            prestatarioExistente.PrestatarioId = prestatario.PrestatarioId;



            // Actualiza otras propiedades según sea necesario

            try
            {
                context.Prestatarios.Update(prestatarioExistente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var prestatario = await context.Prestatarios.FindAsync(id);

            if (prestatario == null)
            {
                return NotFound($"El prestatario {id} no fue encontrado");
            }

            context.Prestatarios.Remove(prestatario);
            await context.SaveChangesAsync();

            return Ok($"Prestatario {id} eliminado exitosamente");
        }
    }
}
