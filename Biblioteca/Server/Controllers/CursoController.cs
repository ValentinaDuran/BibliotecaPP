using Biblioteca.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Controllers
{

    [ApiController]
    [Route("api/CursoController")]
    public class CursoController : ControllerBase
    {
        private readonly BDContext context;

        public CursoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            return await context.Cursos.ToListAsync();
                      

        }

    }
}
