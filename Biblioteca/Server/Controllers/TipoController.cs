using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Controllers
{
    [ApiController]
    [Route("api/TipoController")]
    public class TipoController : ControllerBase
    {
        private readonly BDContext context;

        public TipoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tipo>>> Get()
        {
            return await context.Tipos
                      .ToListAsync();


        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tipo>> Get(int id)
        {
            var tipo = await context.Tipos
                .Where(o => o.TipoId == id)
                .FirstOrDefaultAsync();
            if (tipo == null)
            {
                return NotFound($"No existe ese material en el inventario de Id={id}");
            }
            return tipo;
        }
    }

}
