using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/MaterialMalEstadoController")]
    public class MaterialMalEstadoController : ControllerBase
    {
        private readonly BDContext context;

        public MaterialMalEstadoController(BDContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<MaterialMalEstado>>> Get()
        {
            return await context.MaterialesMalEstado
                          //.Include(i => i.Inventario)
                          .Where(i => i.Activo == false)
                          .ToListAsync();

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MaterialMalEstado>> Get(int id)
        {
            var material = await context.MaterialesMalEstado
                //.Include(i => i.MaterialMalEstado)
                .Where(o => o.MaterialMalEstadoId == id)
                .FirstOrDefaultAsync();
            if (material == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return material;
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var material = context.MaterialesMalEstado.Where(x => x.MaterialMalEstadoId == id).FirstOrDefault();

            if (material == null)
            {
                return NotFound($"El Tipo Documento {id} no fue encontrado");
            }
            if (material != null)
            {
                material.Activo = true;
                context.SaveChanges();

            }
            return Ok();
        }
        //ACTUALIZACION DE INVENTARIO
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] MaterialMalEstado material)
        {
            if (id != material.MaterialMalEstadoId)
            {
                return BadRequest("IDs no coinciden");
            }

            var malmaterialExistente = context.MaterialesMalEstado.SingleOrDefault(e => e.MaterialMalEstadoId == id);

            if (malmaterialExistente == null)
            {
                return NotFound("No existe el inventario");
            }

            malmaterialExistente.Activo=material.Activo;



            // Actualiza otras propiedades según sea necesario

            try
            {
                context.MaterialesMalEstado.Update(malmaterialExistente);
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
