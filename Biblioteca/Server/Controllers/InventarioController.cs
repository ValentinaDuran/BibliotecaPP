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
            return await context.Inventarios.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Inventario>> Get(int id)
        {
            var inventario = await context.Inventarios.Where(o => o.InventarioId == id).FirstOrDefaultAsync();
            if (inventario == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return inventario;
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
        public async Task<ActionResult<int>> Post(Inventario inventario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
            var BibliotecaPractica = context.Inventarios.Where(x => x.InventarioId == id).FirstOrDefault();
            if (BibliotecaPractica == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Inventarios.Remove(BibliotecaPractica);
                context.SaveChanges();
                return Ok($"El registro de {BibliotecaPractica.Material} ha sido eliminado");
            }
            catch (Exception o)
            {
                return BadRequest($"No se logro eliminar por:{o.Message}");

            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Inventario inventario)
        {
            if (id != inventario.InventarioId)
            {
                return BadRequest("IDs no coinciden");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Entry(inventario).State = EntityState.Modified;
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
