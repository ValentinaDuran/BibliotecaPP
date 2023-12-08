using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                      .Where(i => i.Activo == true)
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

                // No es necesario recuperar y establecer la propiedad Tipo. Simplemente confía en TipoId.
                // Solo verifica si el TipoId proporcionado realmente existe en la base de datos.
                var exists = await context.Tipos.AnyAsync(t => t.TipoId == inventario.TipoId);
                if (!exists)
                {
                    return NotFound($"El tipo con ID {inventario.TipoId} no fue encontrado.");
                }

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

            inventarioExistente.Codigo = inventario.Codigo;
            inventarioExistente.TituloNombre = inventario.TituloNombre;
            inventarioExistente.AutorMarca = inventario.AutorMarca;
            inventarioExistente.Observacion = inventario.Observacion;
            inventarioExistente.TipoId = inventario.TipoId;
            inventarioExistente.Tipo = inventario.Tipo;
            inventarioExistente.Activo = inventario.Activo;

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