using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/InventarioController")]
    public class InventarioController : ControllerBase 
    {
        private readonly BDContext context;

        public InventarioController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Inventario>>> Get()
        {
            return await context.Inventarios
                      .Include(i => i.Tipo)
                      .Where(i =>i.Activo == true)
                      .ToListAsync();


        }

        [HttpGet("pasar-true")]
        public async Task<ActionResult<List<Inventario>>> GetPasarTrue()
        {
            return await context.Inventarios
                .Include(i => i.Tipo)
                .Where(i => i.Pasar)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Inventario>> Get(int id)
        {
            var inventario = await context.Inventarios
                .Include(i => i.Tipo)
                .Where(o => o.InventarioId == id)
                .FirstOrDefaultAsync();
            if (inventario == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return inventario;
        }


        //AGREGA UN NUEVO MATERIAL A INVENTARIO
        [HttpPost]
        public async Task<ActionResult<int>> Post(Inventario inventario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verifica si ya existe un elemento con el mismo código
                var codigoExists = await context.Inventarios.AnyAsync(i => i.Codigo == inventario.Codigo);

                if (codigoExists)
                {
                    ModelState.AddModelError("Codigo", "El código ya existe. Debe ser único.");
                    return BadRequest(ModelState);
                }
                // Validación para caracteres especiales excluyendo la "ñ"
                if (!Regex.IsMatch(inventario.Codigo, @"^[a-zA-Z0-9ñÑ]+$"))
                {
                    ModelState.AddModelError("Codigo", "El código no puede contener caracteres especiales, excepto la letra 'ñ'.");
                    return BadRequest(ModelState);
                }


                // No es necesario recuperar y establecer la propiedad Tipo. Simplemente confía en TipoId.
                // Solo verifica si el TipoId proporcionado realmente existe en la base de datos.
                var exists = await context.Tipos.AnyAsync(t => t.TipoId == inventario.TipoId);
                if (!exists)
                {
                    return NotFound($"El tipo con ID {inventario.TipoId} no fue encontrado.");
                }
                var caracterEsp= await context.Inventarios.AnyAsync();
                    


                // Añade el objeto Inventario al contexto y guarda los cambios
                context.Inventarios.Add(inventario);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = inventario.InventarioId }, inventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("activar/{id:int}")]
        public ActionResult Activar(int id)
        {
            var inventario = context.Inventarios.SingleOrDefault(e => e.InventarioId == id);

            if (inventario == null)
            {
                return NotFound("No existe el inventario");
            }

            inventario.Activo = true;

            try
            {
                context.Inventarios.Update(inventario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

        [HttpPut("pasar/{id:int}")]
        public ActionResult Pasar(int id)
        {
            var inventario = context.Inventarios.SingleOrDefault(e => e.InventarioId == id);

            if (inventario == null)
            {
                return NotFound("No existe el inventario");
            }

            inventario.Pasar = true;

            try
            {
                context.Inventarios.Update(inventario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

        [HttpPut("buenestado/{id:int}")]
        public ActionResult CambiarBuenEstado(int id)
        {
            var inventario = context.Inventarios.SingleOrDefault(e => e.InventarioId == id);

            if (inventario == null)
            {
                return NotFound("No existe el inventario");
            }

            inventario.Pasar = false;
            inventario.Activo = true;

            try
            {
                context.Inventarios.Update(inventario);
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
            var inventario = context.Inventarios.Where(x => x.InventarioId == id).FirstOrDefault();

            if (inventario == null)
            {
                return NotFound($"El Tipo Documento {id} no fue encontrado");
            }
            if (inventario != null)
            {
                inventario.Activo = false;
                context.SaveChanges();

            }
            return Ok();
        }
        //ACTUALIZACION DE INVENTARIO
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Inventario inventario)
        {
            if (id != inventario.InventarioId)
            {
                return BadRequest("IDs no coinciden");
            }

            var inventarioExistente = context.Inventarios.SingleOrDefault(e => e.InventarioId == id);

            if (inventarioExistente == null)
            {
                return NotFound("No existe el inventario");
            }

            // Verifica si ya existe un inventario con el mismo código
            var codigoExists = context.Inventarios.Any(i => i.Codigo == inventario.Codigo && i.InventarioId != id);

            if (codigoExists)
            {
                ModelState.AddModelError("Codigo", "El código de inventario ya existe. Debe ser único.");
                return BadRequest(ModelState);
            }

            // Validación para caracteres especiales excluyendo la "ñ"
            if (!Regex.IsMatch(inventario.Codigo, @"^[a-zA-Z0-9ñÑ]+$"))
            {
                ModelState.AddModelError("Codigo", "El código no puede contener caracteres especiales, excepto la letra 'ñ'.");
                return BadRequest(ModelState);
            }

            inventarioExistente.Codigo = inventario.Codigo;
            inventarioExistente.TituloNombre = inventario.TituloNombre;
            inventarioExistente.AutorMarca = inventario.AutorMarca;
            inventarioExistente.Observacion = inventario.Observacion;
            inventarioExistente.TipoId = inventario.TipoId;
            inventarioExistente.Tipo = inventario.Tipo;


            // Actualiza otras propiedades según sea necesario

            try
            {
                context.Inventarios.Update(inventarioExistente);
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
