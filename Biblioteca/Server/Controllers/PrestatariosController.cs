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
    }
}
